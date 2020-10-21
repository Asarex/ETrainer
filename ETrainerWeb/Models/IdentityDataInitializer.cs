using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ETrainerWeb.Models
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

			var userExist = await roleManager.RoleExistsAsync("User");
			if (!userExist)
			{
				var role = new IdentityRole("User");
				await roleManager.CreateAsync(role);
			}
		}

		public static async Task SeedUsers(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			var admin = await userManager.FindByNameAsync("Admin");
			if (admin is null)
			{
				admin = new User { UserName = "Admin" };
				var res = await userManager.CreateAsync(admin, "notAdmin1@");
				if (res.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, "Admin");
				}
			}
		}
	}
}
