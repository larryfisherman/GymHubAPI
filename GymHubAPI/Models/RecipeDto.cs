using GymHubAPI.Entities;

namespace GymHubAPI.Models
{
    public class RecipeDto
    {
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
        public ICollection<RecipeCategories>? Categories { get; set; }
    
    }
}