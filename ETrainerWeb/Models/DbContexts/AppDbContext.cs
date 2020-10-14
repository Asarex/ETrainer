using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			var splitStringConverter =
				new ValueConverter<IEnumerable<int>, string>(v => string.Join(";", v), v => v.Split(new[] {';'}).Select(v => int.Parse(v)));
			builder.Entity<WorkoutSettings>().Property(nameof(WorkoutSettings.IncludeMuscleses))
				.HasConversion(splitStringConverter);
			builder.Entity<WorkoutSettings>().Property(nameof(WorkoutSettings.ExcludeMuscleses))
				.HasConversion(splitStringConverter);
			builder.Entity<WorkoutSettings>().Property(nameof(WorkoutSettings.IncludeExercises))
				.HasConversion(splitStringConverter);
			builder.Entity<WorkoutSettings>().Property(nameof(WorkoutSettings.ExcludeExercises))
				.HasConversion(splitStringConverter);
			builder.Entity<Exercise>().Property(nameof(Exercise.UseMuscles))
				.HasConversion(splitStringConverter);
		}
	}
}
