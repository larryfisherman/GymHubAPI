namespace GymHubAPI.Entities
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Title { get; set; }
        public int Sets { get; set; }
        public int Repeats { get; set; }

        public ICollection<Workout> Workouts { get; set; }

    }
}
