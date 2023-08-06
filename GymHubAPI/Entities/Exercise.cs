using System.Text.Json.Serialization;

namespace GymHubAPI.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Title { get; set; }
        public int Sets { get; set; }
        public int Repeats { get; set; }

        [JsonIgnore]
        public List<WorkoutExercises>? WorkoutExercises { get; set; }
    }
}
