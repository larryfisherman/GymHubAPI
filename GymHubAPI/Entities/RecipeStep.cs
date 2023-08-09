using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class RecipeStep
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        
        [JsonIgnore]
        public int? RecipeId { get; set; }

        [JsonIgnore]
        public Recipe? Recipe { get; set; }
    }
}
