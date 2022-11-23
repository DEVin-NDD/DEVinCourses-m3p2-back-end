using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TrainingActivityController : ControllerBase
    {
        private readonly ITrainingActivityService _activityService;

        public TrainingActivityController(ITrainingActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpPost]

        public IActionResult Insert(TrainingActivityDTO activity) 
        {
            _activityService.Insert(activity);

            return  Ok(activity);
        }


        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
           return Ok(_activityService.getAll());
        }

        [HttpPut()]
        public IActionResult PutByIdActivity(int id, string description)
        {
            _activityService.Update(id, description);
            return Ok();
        }
    }
}
