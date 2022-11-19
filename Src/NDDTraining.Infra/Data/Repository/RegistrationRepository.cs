using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.DTOS;
using Microsoft.EntityFrameworkCore;

namespace NDDTraining.Infra.Data.Repository
{
    public class RegistrationRepository : BaseRepository<Registration, int>, IRegistrationRepository

    {

        public RegistrationRepository(NDDTrainingDbContext context) : base(context)
        {
        }

        public IList<Registration> GetAll()
        {
            return _context.Registrations.ToList();
        }


        public override void Insert(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

        public bool RegistrationDuplicate(int id)
        {
            return _context.Registrations.Any(x => x.Id == id);
        }

        public void Delete(int userId)
        {

            var user = _context.Registrations.Find(userId);

            _context.Registrations.Remove(user);
            _context.SaveChanges();
        }

        public bool DeleteNoRegistration(int userId)
        {
            var user = _context.Registrations.Find(userId);
            if (user == null) return true;
            else return false;

        }

        public void DeleteRegistration(Registration registration)
        {
            _context.Registrations.Remove(registration);
            _context.SaveChanges();
        }
   

        public IQueryable<Registration> GetRegistrationsByUser(int id)
        {
            return _context.Registrations.Where(r => r.UserId == id).Include(r => r.Training);
        }
    }

}