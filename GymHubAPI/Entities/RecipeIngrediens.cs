﻿namespace GymHubAPI.Entities
{
    public class RecipeIngrediens
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
