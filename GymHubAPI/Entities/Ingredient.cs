namespace GymHubAPI.Entities
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carbs { get; set; }
        public int Kcal { get; set; }
        public int Amount { get; set; }
    }
}
