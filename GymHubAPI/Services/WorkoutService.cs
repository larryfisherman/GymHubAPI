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
        public object GetWorkoutById(int id);
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

        public object GetWorkoutById(int id)
        {
            var workout = _dbContext
              .Workouts
              .FirstOrDefault(w => w.WorkoutId == id);

            var exercises = GetExercisesByWorkoutId(id);

            if (workout is null) throw new NotFoundException("Workout not found");

            var result = _mapper.Map<WorkoutDto>(workout);

            return new
            {
                workout = workout,
                exercises = exercises,
            };
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

            AddExercisesToWorkout(id, dto.WorkoutExercises);

            _dbContext.SaveChanges();
        }


        private void AddExercisesToWorkout(int workoutId, List<WorkoutExercisesDto> exercises)
        {
            var workout = _dbContext.Workouts.Find(workoutId);

            if (workout is null) throw new NotFoundException("Workout not found");
   
                var existingExercises = _dbContext.WorkoutsExercises
                    .Where(we => we.WorkoutId == workout.WorkoutId)
                    .ToList();

               if(existingExercises.Count > 0) RemoveExercisesConnectedToWorkout(workoutId, exercises);

                foreach (var exercise in exercises)
                {
                    var existingExercise = existingExercises.FirstOrDefault(we => we.ExerciseId == exercise.ExerciseId);

                    if (existingExercise == null)
                    {
                        var workoutExercise = new WorkoutExercises
                        {
                            WorkoutId = workout.WorkoutId,
                            ExerciseId = exercise.ExerciseId,
                            Sets = exercise.Sets,
                            Repeats = exercise.Repeats,
                        };

                        _dbContext.WorkoutsExercises.Add(workoutExercise);
                    }
                    else
                    {
                        existingExercise.Sets = exercise.Sets;
                        existingExercise.Repeats = exercise.Repeats;
                    }
                }

            _dbContext.SaveChanges();
        }

        private void RemoveExercisesConnectedToWorkout(int workoutId, List<WorkoutExercisesDto> exercises)
        {
            var receivedExerciseIds = exercises.Select(e => e.ExerciseId).ToList();
            var workout = _dbContext.Workouts.Find(workoutId);


            if (receivedExerciseIds == null || receivedExerciseIds.Count == 0)
            {
                var workoutExercisesToRemove = _dbContext.WorkoutsExercises
                    .Where(we => we.WorkoutId == workoutId)
                    .ToList();

                _dbContext.WorkoutsExercises.RemoveRange(workoutExercisesToRemove);
            }
            else
            {
                var exercisesToRemove = workout.WorkoutExercises
                    .Where(we => !receivedExerciseIds.Contains(we.ExerciseId))
                    .ToList();

                _dbContext.WorkoutsExercises.RemoveRange(exercisesToRemove);
            }
        }

        private List<WorkoutExercisesDto> GetExercisesByWorkoutId(int workoutId)
        {
            var exerciseIds = _dbContext.WorkoutsExercises
                .Where(we => we.WorkoutId == workoutId)
                .ToList();

            var exercises = _mapper.Map<List<WorkoutExercisesDto>>(exerciseIds);
            return exercises;
        }
    }
}
