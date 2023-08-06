using AutoMapper;
using GymHubAPI.Entities;
using GymHubAPI.Models;

namespace GymHubAPI
{
    public class GymHubMappingProfile : Profile
    {
        public GymHubMappingProfile()
        {
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, Recipe>();

            CreateMap<Workout, WorkoutDto>();
            CreateMap<WorkoutDto, Workout>();

            CreateMap<WorkoutExercises, WorkoutExercisesDto>();
            CreateMap<WorkoutExercisesDto, WorkoutExercises>();

            CreateMap<RecipeIngredients, RecipeIngredientsDto>();
            CreateMap<RecipeIngredientsDto, RecipeIngredients>();

            CreateMap<Ingredient, RecipeIngredientsDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}