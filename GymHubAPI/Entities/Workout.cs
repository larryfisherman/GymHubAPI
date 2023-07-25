using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }
        public int? Kcal { get; set; }
        public int? TimeToBeDone { get; set; }

        [JsonIgnore]
        public List<WorkoutExercises>? WorkoutExercises { get; set;}
    }
}
