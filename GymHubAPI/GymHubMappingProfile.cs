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
        }
    }
}