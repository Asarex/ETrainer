using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWebAPI.Models.DbContexts
{
	public class ETrainerIdentityDbContext : IdentityDbContext<ETrainerUser>
	{
		public ETrainerIdentityDbContext(DbContextOptions<ETrainerIdentityDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<ETrainerUser>().HasIndex(u => u.UserName).IsUnique();
		}
	}
}
