using ETrainerWeb.Models.JoinModels;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWeb.Models.DbContexts
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Muscle> Muscles { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<WorkoutSettings> WorkoutSettingses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Muscle *-* Exercise
			modelBuilder.Entity<MuscleExercise>().HasKey(me => new {me.MuscleID, me.ExerciseID});
			modelBuilder.Entity<MuscleExercise>().HasOne(me => me.Muscle).WithMany(m => m.MuscleExercises)
				.HasForeignKey(me => me.MuscleID);
			modelBuilder.Entity<MuscleExercise>().HasOne(me => me.Exercise).WithMany(m => m.MuscleExercises)
				.HasForeignKey(me => me.ExerciseID);

			//WorkoutSettings *-* Muscle
			//Include muscles
			modelBuilder.Entity<WorkoutSettingsIncludeMuscles>().HasKey(wi => new {wi.WorkoutSettingsID, wi.MuscleID});
			modelBuilder.Entity<WorkoutSettingsIncludeMuscles>().HasOne(wi => wi.WorkoutSettings)
				.WithMany(w => w.WorkoutSettingsIncludeMuscleses);
			modelBuilder.Entity<WorkoutSettingsIncludeMuscles>().HasOne(wi => wi.Muscle)
				.WithMany(m => m.IncludeInSettings);

			//ExcludeMuscles
			modelBuilder.Entity<WorkoutSettingsExcludeMuscles>().HasKey(wi => new { wi.WorkoutSettingsID, wi.MuscleID });
			modelBuilder.Entity<WorkoutSettingsExcludeMuscles>().HasOne(wi => wi.WorkoutSettings)
				.WithMany(w => w.WorkoutSettingsExcludeMuscles);
			modelBuilder.Entity<WorkoutSettingsExcludeMuscles>().HasOne(wi => wi.Muscle)
				.WithMany(m => m.ExcludeFromSettings);
		}
	}
}
