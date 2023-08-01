﻿using GymHubAPI.Entities;
using GymHubAPI.Models;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly GymHubDbContext _dbContext;

        public WorkoutController(IWorkoutService workoutService, GymHubDbContext dbContext)
        {
            _workoutService = workoutService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkoutDto>> GetAllWorkouts()
        {
            var workouts = _workoutService.GetAllWorkouts();

            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public ActionResult<WorkoutDto> GetWorkoutById([FromRoute] int id)
        {
            object workout = _workoutService.GetWorkoutById(id);
            return Ok(workout);
        }

        [HttpPost]
        public ActionResult CreateWorkout([FromBody] WorkoutDto dto)
        {
            _workoutService.Create(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _workoutService.Delete(id);
            return Ok("Workout removed");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWorkout([FromRoute] int id, [FromBody] WorkoutDto dto)
        {
            _workoutService.Update(id, dto);

            return Ok();
        }


    }
}
