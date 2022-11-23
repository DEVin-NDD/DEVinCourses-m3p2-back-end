using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Exceptions;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTraining.Domain.Services
{
    public class TrainingActivityService : ITrainingActivityService
    {
        private readonly ITrainingActivityRepository _activityRepository;

        public TrainingActivityService (ITrainingActivityRepository activityService)
        {
            _activityRepository = activityService;
        }

        public void Insert(TrainingActivityDTO activity)
        {
            TrainingActivity trainingActivity = new(activity);
            _activityRepository.Insert(trainingActivity);

        }

        public IList<TrainingActivity> getAll()
        {
            return _activityRepository.GetAll(new Paging(20,0));
        }
    }
}
