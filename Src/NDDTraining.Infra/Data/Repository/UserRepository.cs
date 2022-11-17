using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.Interfaces.Repositories;

namespace NDDTraining.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(NDDTrainingDbContext context) : base(context) { }

        public User GetByToken(string id)
        {
            throw new NotImplementedException();
        }
    }
}

