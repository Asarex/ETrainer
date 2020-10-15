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
	}
}
