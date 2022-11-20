using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class CompletedModulesController : Controller
    {
        private readonly ICompletedModuleService _completedModuleService;


        public CompletedModulesController(ICompletedModuleService completedModuleService)
        {
            _completedModuleService = completedModuleService;
        }

        [HttpPost]
        public IActionResult Insert(CompletedModuleDTO completed)
        {

            _completedModuleService.Insert(completed);

            return StatusCode(StatusCodes.Status201Created);

        }


    }
}
