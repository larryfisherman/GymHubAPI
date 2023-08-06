using System.Text.Json.Serialization;

namespace GymHubAPI.Models
{
    public class WorkoutExercisesDto
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Repeats { get; set; }
    }
}