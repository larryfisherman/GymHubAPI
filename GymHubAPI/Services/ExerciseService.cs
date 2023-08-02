using AutoMapper;
using GymHubAPI.Entities;
using GymHubAPI.Exceptions;

namespace GymHubAPI.Services
{
        public interface IExerciseService
        {
            public IEnumerable<Exercise> GetAllExercises();
            public void Create(Exercise dto);
            public void Delete(int id);
            public Exercise GetExerciseById(int id);

        }
        public class ExerciseService : IExerciseService
        {
            private readonly GymHubDbContext _dbContext;
            private readonly IMapper _mapper;

            public ExerciseService(GymHubDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public IEnumerable<Exercise> GetAllExercises()
            {
                return _dbContext.Exercises.ToList();
            }

            public void Create(Exercise dto)
            {
                _dbContext.Exercises.Add(dto);
                _dbContext.SaveChanges();
            }

            public void Delete(int id)
            {
                var exercise = _dbContext.Exercises.FirstOrDefault(e => e.ExerciseId == id);

                if (exercise is null) throw new NotFoundException("Exercise not found");

                _dbContext.Exercises.Remove(exercise);
                _dbContext.SaveChanges();
            }

            public Exercise GetExerciseById(int id)
            {
                var exercise = _dbContext
                  .Exercises
                  .FirstOrDefault(i => i.ExerciseId == id);


                if (exercise is null) throw new NotFoundException("Exercise not found");

                return exercise;
            }

        }
    }
