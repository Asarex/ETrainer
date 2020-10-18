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
	}
}
