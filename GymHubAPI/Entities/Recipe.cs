using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? Protein { get; set; }
        public int? Fat { get; set; }
        public int? Carbo { get; set; }
        public int? Kcal { get; set; }
        public int? TimeToBeDone { get; set; }
        public int? CategoryId { get; set; }


        [JsonIgnore]
        public List<RecipeIngredients>? RecipeIngredients { get; set; }
        [JsonIgnore]
        public List<RecipeSteps>? RecipeSteps { get; set; }
    }
}
