using System.Threading.Tasks;
using ETrainerWebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ETrainerWebAPI
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var serviceProvider = scope.ServiceProvider;
	
				var userManager = serviceProvider.
					GetRequiredService<UserManager<ETrainerUser>>();

				var roleManager = serviceProvider.
					GetRequiredService<RoleManager<IdentityRole>>();

				await IdentityDataInitializer.SeedRoles(roleManager);
				await IdentityDataInitializer.SeedUsers(userManager, roleManager);

			}
			host.Run();
        }

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
