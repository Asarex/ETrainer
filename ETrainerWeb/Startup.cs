using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWeb.Models;
using ETrainerWeb.Models.DbContexts;
using ETrainerWeb.Models.Repositories;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using ETrainerWeb.Models.Repositories.MusclesRepositories;
using ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

namespace ETrainerWeb
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews().AddDataAnnotationsLocalization().AddViewLocalization().AddRazorRuntimeCompilation();
			services.AddRazorPages();
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
			services.AddDbContextPool<AppIdentityDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
			services.AddDbContextPool<AppDbContext>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));

			services.AddScoped<IMusclesRepository, MusclesRepository>();
			services.AddScoped<IExercisesRepository, ExercisesRepository>();
			services.AddScoped<IWorkoutSettingsRepository, WorkoutSettingsRepository>();

			services.Configure<RequestLocalizationOptions>(options =>
			{
				var supportedCultures = new[]
				{
					new CultureInfo("en"),
					new CultureInfo("ru")
				};

				options.DefaultRequestCulture = new RequestCulture("en");
				options.SupportedCultures = supportedCultures;
				options.SupportedUICultures = supportedCultures;
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRequestLocalization();

			app.UseStaticFiles();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
