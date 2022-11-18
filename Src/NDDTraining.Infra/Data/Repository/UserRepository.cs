using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;

namespace NDDTraining.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(NDDTrainingDbContext context) : base(context) { }

        public User CheckUserByEmail (string email)
        {
            var checkedUser = _context.Users.FirstOrDefault(u => u.Email == email);
            return(checkedUser);
        }

        public User CheckUserByCPF (string cpf)
        {
            var checkedUser = _context.Users.FirstOrDefault(c => c.CPF == cpf);
            return(checkedUser);
        }

        public bool VerifyLogin(Login login)
        {
            return _context.Users.Any(u => u.Email == login.Email && u.Password == login.Password);
        }

        public User GetByToken(string id)
        {
            throw new NotImplementedException();
        }
    }
}
