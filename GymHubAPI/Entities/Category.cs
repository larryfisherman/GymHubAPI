using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImgSrc { get; set; }

        [JsonIgnore]
        public List<RecipeCategories>? RecipeCategories { get; set; }

    }
}
