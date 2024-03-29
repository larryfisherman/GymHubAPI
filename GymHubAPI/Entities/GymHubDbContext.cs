﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymHubAPI.Entities
{
    public class GymHubDbContext : DbContext
    {

        public GymHubDbContext(DbContextOptions<GymHubDbContext> options) : base(options) 
        {
                
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercises> WorkoutsExercises { get;set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            var account = modelBuilder.Entity<User>();
            account.Property(a => a.Email).IsRequired();
            account.Property(a => a.PasswordHash).IsRequired();

            modelBuilder.Entity<WorkoutExercises>().HasOne(w => w.Workout).WithMany(w => w.WorkoutExercises).HasForeignKey(w => w.WorkoutId);

            modelBuilder.Entity<WorkoutExercises>().HasOne(e => e.Exercise).WithMany(w => w.WorkoutExercises).HasForeignKey(w => w.ExerciseId);

            modelBuilder.Entity<RecipeIngredients>().HasOne(ri => ri.Recipe).WithMany(r => r.RecipeIngredients).HasForeignKey(ri => ri.RecipeId); 

            modelBuilder.Entity<RecipeIngredients>().HasOne(ri => ri.Ingredient).WithMany(i => i.RecipeIngredients).HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<RecipeStep>().HasOne(w => w.Recipe).WithMany(ri => ri.RecipeSteps).HasForeignKey(r => r.RecipeId);

        }
    }
}
