using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Repositories
{
    public interface ITrainingActivityRepository : IBaseRepository<TrainingActivity, int>
    {
        void Insert(TrainingActivity trainingActivity);
    }
}
