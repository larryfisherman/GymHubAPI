namespace GymHubAPI.Models
{
    public class WorkoutDto
    {
        public string Title { get; set; }
        public int Kcal { get; set; }
        public int TimeToBeDone { get; set; }
        public bool Favourite { get; set; }
    }
}
