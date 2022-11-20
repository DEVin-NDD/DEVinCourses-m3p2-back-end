using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using NDDTraining.Domain.DTOS;
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
    
        public class CompletedModuleRepository : BaseRepository<CompletedModule, int>, ICompletedModuleRepository
        {

            public CompletedModuleRepository(NDDTrainingDbContext context) : base(context)
            {
            }

            public List<CompletedModule> GetCompletModuleRegistrationsId(CompletedModuleDTO completed)
            {

                return _context.CompletedModule.Where(m => m.RegistrationId == completed.RegistrationId).ToList();
            }

            public void Insert(CompletedModule completed)
            {
                _context.CompletedModule.Add(completed);
                _context.SaveChanges();
            }
        }
    }


