namespace GymHubAPI.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Kcal { get; set; }
        public int Protein { get; set; }
        public int Carbo {get; set; }
        public int Fat { get; set; }    

    }
}
