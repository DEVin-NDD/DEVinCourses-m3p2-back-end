using NDDTraining.Domain.DTOS;
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
        public void Insert(CompletedModule completed);
        public List<CompletedModule> GetCompletModuleRegistrationsId(CompletedModuleDTO completed);

    }
}
