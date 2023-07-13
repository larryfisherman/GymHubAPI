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
        public DbSet<RecipeIngrediens> RecipeIngrediens { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }
        public DbSet<WorkoutExercises> WorkoutExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            var account = modelBuilder.Entity<User>();
            account.Property(a => a.Email).IsRequired();
            account.Property(a => a.PasswordHash).IsRequired();

            //modelBuilder.Entity<RecipeCategories>().HasData(
            //    new RecipeCategories { Id = 1, Title = "All dishes"},
            //    new RecipeCategories { Id = 2, Title = "Meat dishes" },
            //    new RecipeCategories { Id = 3, Title = "Salads" },
            //    new RecipeCategories { Id = 4, Title = "Seafood" },
            //    new RecipeCategories { Id = 5, Title = "Soups" },
            //    new RecipeCategories { Id = 6, Title = "Desserts" }
            //   );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
