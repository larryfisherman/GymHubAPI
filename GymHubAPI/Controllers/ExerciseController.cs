using GymHubAPI.Entities;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers
{
        [Route("api/exercises")]
        [ApiController]
        public class ExerciseController : ControllerBase
        {
            private readonly IExerciseService _exerciseService;

            public ExerciseController(IExerciseService exerciseService)
            {
                _exerciseService = exerciseService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Exercise>> GetAllExercises()
            {
                var exercise = _exerciseService.GetAllExercises();

                return Ok(exercise);
            }

            [HttpGet("{id}")]
            public ActionResult<Exercise> GetExerciseById([FromRoute] int id)
            {
                object exercise = _exerciseService.GetExerciseById(id);
                return Ok(exercise);
            }

            [HttpPost]
            public ActionResult CreateExercise([FromBody] Exercise dto)
            {
                _exerciseService.Create(dto);
                return Ok();
            }

            [HttpDelete("{id}")]
            public ActionResult Delete([FromRoute] int id)
            {
                _exerciseService.Delete(id);
                return Ok("Exercise removed");
            }
        }
    }
