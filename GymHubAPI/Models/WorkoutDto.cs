using GymHubAPI.Entities;

namespace GymHubAPI.Models
{
    public class WorkoutDto
    {
        public int WorkoutId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }
        public int? Kcal { get; set; }
        public int? TimeToBeDone { get; set; }

        public List<WorkoutExercises>? WorkoutExercises { get; set; }
    }
}
