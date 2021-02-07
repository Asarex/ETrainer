using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWebAPI.Models
{
	public class IdentityDataInitializer
	{
		public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
		{
			var adminExist = await roleManager.RoleExistsAsync("Admin");
			if (!adminExist)
			{
				var role = new IdentityRole("Admin");
				await roleManager.CreateAsync(role);
			}

			var userExist = await roleManager.RoleExistsAsync("CommonUser");
			if (!userExist)
			{
				var role = new IdentityRole("ETrainerUser");
				await roleManager.CreateAsync(role);
			}
		}

		public static async Task SeedUsers(UserManager<ETrainerUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var admin = await userManager.FindByNameAsync("Admin");
			if (admin is null)
			{
				try
				{
					admin = new ETrainerUser { UserName = "Admin" , DisplayedName = "Administrator"};
					var res = await userManager.CreateAsync(admin, "notAdmin1@");
					if (res.Succeeded)
					{
						await userManager.AddToRoleAsync(admin, "Admin");
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
					throw;
				}
				
			}
		}
	}
}
