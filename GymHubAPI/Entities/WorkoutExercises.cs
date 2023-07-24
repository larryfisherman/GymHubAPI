namespace GymHubAPI.Entities
{
    public class WorkoutExercises
    {
        public int WorkoutId { get; set; }

        public Exercise? Exercise { get; set; }
    }
}
