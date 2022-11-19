using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Enums;
using NDDTraining.Domain.Exceptions;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Services
{

    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IEmailService _emailService;
        private readonly ICompletedModuleService _completedModuleService;
        private readonly ITrainingService _trainingService;



        public RegistrationService(IRegistrationRepository registrationRepository, IEmailService emailService, ITrainingService trainingService
            )
        {
            _registrationRepository = registrationRepository;
            _emailService = emailService;
            // _userService = userService;
            _trainingService = trainingService;
        }

        public IList<RegistrationDTO> GetAll()
        {
            return _registrationRepository.GetAll()
                  .Select(x => new RegistrationDTO(x)).ToList();

        }

        public void Insert(RegistrationDTO registration)
        {

          
            _registrationRepository.Insert(new Registration(registration));
            _completedModuleService.Validate(registration);

            var training = _trainingService.GetById(registration.TrainingId);
            var user = new User()
            {
                Id = 0,
                Age = 100,
                Email = "lucas@gmail.com",
                Name = "Lucas",

            };

            SendEMail(training.Title, user, training.Description, user.Name, training.Duration, training.Teacher, training.Url);


        }

        public void ValidateRegistration() { 

           
        }



        public void SendEMail(
             string nameCourse,
             User user,
             string description,
             string nameUser,
             TimeSpan duration,
             string teacher,
             string url
            
            )
        {
            _emailService.BuildAndSendMail(new Email()
            {
                To = user.Email,
                Subject = "Cadastramento no curso NDDTrainig",
                type = Enums.EmailType.Registration,
                Parameters = new Dictionary<string, string>()
            {
                {"user", nameUser},
                {"training", nameCourse},
                {"description", description},
                {"duration", duration.ToString() },
                {"teacher",teacher },
                {"url" , url}

            }
            });
        }

        public void ValidateRegistration(RegistrationDTO registration)

        {
            if (_registrationRepository.RegistrationDuplicate(registration.Id))
            {
                throw new DuplicateException("Registro ja existe na base de dados!");
            }

        }

        public void Delete(int id)
        {
            if (_registrationRepository.DeleteNoRegistration(id))
            {
                throw new DeleteNoRegistrationException("Não há arquivo para remoção.");
            }
            _registrationRepository.Delete(id);
        }

        public void DeleteRegistration(int id)
        {
            var registration = _registrationRepository.GetById(id);

            if(registration == null)
            {
                throw new Exception("Modulo não encontrado");
            }
            _registrationRepository.DeleteRegistration(registration);
        }

       public IList<RegistrationDTO> GetRegistrationsByUser(int userId, string status)
        {
            IEnumerable<Registration> trainingWithRegisters = _registrationRepository
                    .GetRegistrationsByUser(userId);

            if(!String.IsNullOrEmpty(status))
            {
                var statusEnum = status.ConvertEnum<Status>();

                trainingWithRegisters = trainingWithRegisters
                    .Where(r => r.Status == statusEnum);
                
            }

            return trainingWithRegisters
                .Select(r => new RegistrationDTO(r)).ToList();
        }
    }

}
