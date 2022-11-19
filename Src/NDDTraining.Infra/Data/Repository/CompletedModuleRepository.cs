using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Infra.Data.Repository
{
    public class CompletedModuleRepository :BaseRepository<CompletedModule, int> , ICompletedModuleRepository
    {

        public CompletedModuleRepository(NDDTrainingDbContext context) : base(context)
        {
        }
      

        public List<Module> GetAllModules()
        {
            return _context.Modules.ToList();
        }

        public void CompletedInsert(CompletedModule completed)
        {
            _context.CompletedModule.Add(completed);
            _context.SaveChanges();
        }

        public List<Registration> GetAllRegistration()
        {
            return _context.Registrations.ToList();
        }

       
     }
}
