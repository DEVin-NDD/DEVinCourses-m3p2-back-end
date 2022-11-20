using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Services
{
    public class CompletedModuleService : ICompletedModuleService
    {

        private readonly ICompletedModuleRepository _completedModuleRepository;

        public CompletedModuleService(ICompletedModuleRepository completedModuleRepository)
        {
            _completedModuleRepository = completedModuleRepository;
        }

        public void Insert(CompletedModuleDTO completed)
        {
            _completedModuleRepository.Insert(new CompletedModule(completed));
        }


    }


}

