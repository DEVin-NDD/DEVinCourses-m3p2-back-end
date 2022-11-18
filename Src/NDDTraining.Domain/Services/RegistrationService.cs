using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Exceptions;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Services
{

    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;



        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public IList<RegistrationDTO> GetAll()
        {
            return _registrationRepository.GetAll()
                  .Select(x => new RegistrationDTO(x)).ToList();

        }

        public void Insert(RegistrationDTO registration)
        {
            if (_registrationRepository.RegistrationDuplicate(registration.Id))
            {
                throw new DuplicateException("Registro ja existe na base de dados!");
            }
            switch (registration.Status)
            {
                case "Progress":
                    _registrationRepository.InsertListProgress(registration);
                    break;
                case "Available":
                    _registrationRepository.InsertListAvailable(registration);
                    break;
                case "Finished":
                    _registrationRepository.InsertListFinished(registration);
                    break;
                case "Suspended":
                    _registrationRepository.InsertListSuspended(registration);
                    break;
                
            }
            _registrationRepository.Insert(new Registration(registration));

        }



        public void SendEMail()
        {
            throw new NotImplementedException();
        }

        public void ValidateRegistration()
        {


        }

        public void Delete(int id)
        {
            if (_registrationRepository.DeleteNoRegistration(id))
            {
                throw new DeleteNoRegistrationException("Não há arquivo para remoção.");
            }
            _registrationRepository.Delete(id);
        }


    }

}