namespace GymHubAPI.Entities
{
    public class RecipeCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }

        public Recipe? Recipe { get; set; }
        public Category? Category { get; set; }
    }
}
