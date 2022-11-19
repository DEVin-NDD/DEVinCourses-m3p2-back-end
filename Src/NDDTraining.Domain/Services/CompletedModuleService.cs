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
    public class CompletedModuleService: ICompletedModuleService
    {

        private readonly ICompletedModuleRepository _completedModuleRepository;


        public List<int> VerifyAllCompletedModules()
        {
            return  _completedModuleRepository.GetAllModules().Where(x => x.StatusModule == "finalizado").Select(x=>x.Id).ToList();

        }

        public void Validate()
        {
            if (VerifyAllCompletedModules().Any() && _completedModuleRepository.GetAllModules().Select(x=>x.TrainingId) == _completedModuleRepository.GetAllRegistration().Select(x=>x.TrainingId))
            {
               
               _completedModuleRepository.CompletedInsert(new CompletedModule());
            }
            

            }
        }

        
    }

