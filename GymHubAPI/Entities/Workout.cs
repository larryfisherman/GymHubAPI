namespace GymHubAPI.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Kcal { get; set; }
        public int TimeToBeDone { get; set; }
        public bool Favourite { get; set; }
    }
}
