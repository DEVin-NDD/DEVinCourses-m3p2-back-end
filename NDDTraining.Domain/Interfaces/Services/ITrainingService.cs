using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface ITrainingService
    {
        public void GetTrainingFinish();
        public void GetTrainingProgress();
        public void DeleteTraining();
        public void FinishTrainig();
    }
}
