using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Repositories
{

    public interface IRegistrationRepository : IBaseRepository<Registration, int>
    {
        IList<Registration>GetAll();
        public void Delete(int id);
      
        bool RegistrationDuplicate(int id);
        public bool DeleteNoRegistration(int id);
        void DeleteRegistration(Registration registration);
        IQueryable<Registration> GetRegistrationsByUser(int id);

    }
}