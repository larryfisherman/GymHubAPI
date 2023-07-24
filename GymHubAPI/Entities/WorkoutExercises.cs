﻿namespace GymHubAPI.Entities
{
    public class WorkoutExercises
    {
        public int Id { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout  { get; set; }

        public int ExerciseId   { get; set; }
        public Exercise Exercise { get; set; }


    }
}
