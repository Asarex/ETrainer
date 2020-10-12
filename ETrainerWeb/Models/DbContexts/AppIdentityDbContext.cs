using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWeb.Models.DbContexts
{
	public class AppIdentityDbContext : IdentityDbContext<User>
	{
		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}
	}
}
