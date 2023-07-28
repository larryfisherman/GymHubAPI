using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymHubAPI.Entities
{
    public class GymHubDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=GymHubDb;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercises> WorkoutsExercises { get;set; }
        public DbSet<RecipeIngrediens> RecipeIngrediens { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            var account = modelBuilder.Entity<User>();
            account.Property(a => a.Email).IsRequired();
            account.Property(a => a.PasswordHash).IsRequired();

            modelBuilder.Entity<WorkoutExercises>().HasOne(w => w.Workout).WithMany(w => w.WorkoutExercises).HasForeignKey(w => w.WorkoutId);

            modelBuilder.Entity<WorkoutExercises>().HasOne(e => e.Exercise).WithMany(w => w.WorkoutExercises).HasForeignKey(w => w.ExerciseId);

            modelBuilder.Entity<RecipeIngrediens>().HasOne(w => w.Recipe).WithMany(ri => ri.RecipeIngrediens).HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<RecipeSteps>().HasOne(w => w.Recipe).WithMany(ri => ri.RecipeSteps).HasForeignKey(r => r.RecipeId);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
