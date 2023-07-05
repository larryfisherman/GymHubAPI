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
        public ICollection<RecipeIngrediens>? Ingrediens { get; set; }
        public ICollection<RecipeSteps>? Steps { get; set; }

    }
}
