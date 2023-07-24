using GymHubAPI.Entities;
using GymHubAPI.Models;
using AutoMapper;
using GymHubAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GymHubAPI.Services
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetAllWorkouts();
        public void Create(WorkoutDto dto);
        public void Delete(int id);
        public WorkoutDto GetWorkoutById(int id);
        public void Update(int id, WorkoutDto dto);

    }

    public class WorkoutService : IWorkoutService
    {
        private readonly GymHubDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkoutService(GymHubDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<Workout> GetAllWorkouts()
        {
            return _dbContext.Workouts.ToList();
        }

        public void Create(WorkoutDto dto)
        {
            var workout = _mapper.Map<Workout>(dto);
            workout.CreatedDate = DateTime.Now;
            _dbContext.Workouts.Add(workout);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var workout = _dbContext.Workouts.FirstOrDefault(r => r.WorkoutId == id);

            if (workout is null) throw new NotFoundException("Workout not found");

            _dbContext.Workouts.Remove(workout);
            _dbContext.SaveChanges();
        }

        public WorkoutDto GetWorkoutById(int id)
        {
            var workout = _dbContext
              .Workouts
              .Include(w => w.WorkoutExercises)
              .Include(we => we.WorkoutExercises)
              .FirstOrDefault(w => w.WorkoutId  == id);

            if (workout is null) throw new NotFoundException("Workout not found");

            var result = _mapper.Map<WorkoutDto>(workout);

            return result;
        }

        public void Update(int id, WorkoutDto dto)
        {
            var workout = _dbContext
                .Workouts
                .FirstOrDefault(w => w.WorkoutId == id);

            if (workout is null) throw new NotFoundException("Workout not found");

            workout.Title = dto.Title;
            workout.Description = dto.Description;
            workout.Author = dto.Author;
            workout.CreatedDate = dto.CreatedDate;
            workout.Kcal = dto.Kcal;
            workout.TimeToBeDone = dto.TimeToBeDone;
            workout.WorkoutExercises = dto.WorkoutExercises;

            _dbContext.SaveChanges();
        }
    }
}
