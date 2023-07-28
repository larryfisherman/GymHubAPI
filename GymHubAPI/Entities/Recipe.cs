﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GymHubAPI.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbo { get; set; }
        public int? Kcal { get; set; }
        public int? TimeToBeDone { get; set; }
        public string? Category { get; set; }
        public List<RecipeIngrediens>? RecipeIngrediens { get; set; }
        public List<RecipeSteps>? RecipeSteps { get; set; }

    }
}
