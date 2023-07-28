namespace GymHubAPI.Entities
{
    public class RecipeSteps
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
