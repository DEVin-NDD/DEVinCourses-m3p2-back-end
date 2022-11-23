using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTraining.Domain.Interfaces.Repositories;
using NDDTraining.Domain.Models;
using NDDTraining.Infra.Data.Context;

namespace NDDTraining.Infra.Data.Repository
{

        public class TrainingActivityRepository : BaseRepository<TrainingActivityRepository, int>
    {

            public TrainingActivityRepository(NDDTrainingDbContext context) : base(context)
            {
            }
        }
}
