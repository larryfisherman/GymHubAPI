﻿using AutoMapper;
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

        }
    }
}