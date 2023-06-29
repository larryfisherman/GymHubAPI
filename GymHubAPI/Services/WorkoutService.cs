using GymHubAPI.Entities;
using GymHubAPI.Models;
using AutoMapper;
using GymHubAPI.Exceptions;

namespace GymHubAPI.Services
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetAllWorkouts();
        public void Create(WorkoutDto dto);
        public void Delete(int id);
        WorkoutDto GetById(int id);
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
            _dbContext.Workouts.Add(workout);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var workout = _dbContext.Workouts.FirstOrDefault(r => r.Id == id);

            if (workout is null) throw new NotFoundException("Workout not found");

            _dbContext.Workouts.Remove(workout);
            _dbContext.SaveChanges();
        }

        public WorkoutDto GetById(int id)
        {
            var workout = _dbContext
              .Workouts
              .FirstOrDefault(r => r.Id == id);

            if (workout is null) throw new NotFoundException("Workout not found");

            var result = _mapper.Map<WorkoutDto>(workout);

            return result;
        }
    }
}
