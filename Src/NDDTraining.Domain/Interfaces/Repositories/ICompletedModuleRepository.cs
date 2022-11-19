using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Repositories
{
    public interface ICompletedModuleRepository
    {
        public void CompletedInsert(CompletedModule completed);
        public List<Module> GetAllModules();
        public List<Registration> GetAllRegistration();
    }
}
