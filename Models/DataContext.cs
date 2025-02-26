using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VorgrakTARpe23.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Exercise>? ExerciseList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    Id = 1,
                    Title = "K�tek�verdused jala t�stega",
                    Description = "Tavalised k�tek�verdused korda m��da jalga t�stes",
                    Intensity = Exercise.ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                },
                new Exercise
                {
                    Id = 2,
                    Title = "Slaalomh�pped",
                    Description = "K�kist h�pped k�ljelt k�ljele",
                    Intensity = Exercise.ExerciseIntensity.High,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10,
                    RestTimeInstructions = "Venita reie esik�lge"
                },
                new Exercise
                {
                    Id = 3,
                    Title = "Alt l�bi jooks",
                    Description = "Toenglamangus jooksmine",
                    Intensity = Exercise.ExerciseIntensity.Normal,
                    RecommendedDurationInSeconds = 40,
                    RecommendedTimeInSecondsBeforeExercise = 10,
                    RecommendedTimeInSecondsAfterExercise = 10
                }
            );
        }
    }
}