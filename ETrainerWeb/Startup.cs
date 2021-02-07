using System;
using System.Globalization;
using System.Linq;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DbContexts;
using ETrainerWebAPI.Repositories.ExercisesRepositories;
using ETrainerWebAPI.Repositories.MusclesRepositories;
using ETrainerWebAPI.Repositories.WorkoutSettingsRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ETrainerWebAPI
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
			services.AddControllers();
			services.AddAutoMapper(typeof(Startup));
			services.AddSwaggerGen();

			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.AddIdentity<ETrainerUser, IdentityRole>().AddEntityFrameworkStores<ETrainerIdentityDbContext>();
			
			services.AddDbContextPool<ETrainerIdentityDbContext>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ETrainerIdentityConnection")));
			
			services.AddDbContextPool<ETrainerDbContext>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ETrainerDbConnection")));

			services.AddScoped<IMusclesRepository, MusclesRepository>();
			services.AddScoped<IExercisesRepository, ExercisesRepository>();
			services.AddScoped<IWorkoutSettingsRepository, WorkoutSettingsRepository>();

			var jwtConfig = Configuration.GetSection("jwtConfig").Get<JwtConfig>();
			services.AddSingleton(jwtConfig);
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = true;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidIssuer = jwtConfig.Issuer,

					ValidateAudience = true,
					ValidAudience = jwtConfig.Audience,

					ValidateLifetime = true,
					ClockSkew = TimeSpan.FromMinutes(1),

					ValidateIssuerSigningKey = true,
					IssuerSigningKey = jwtConfig.GetSymmetricSecurityKey(),
				};
			});
				
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

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETrainerAPI V1");
					c.RoutePrefix = string.Empty;
				});
			}
			else
			{
				app.UseHsts();
				app.UseHttpsRedirection();
			}
			app.UseRequestLocalization();
			
			app.UseRouting();


			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			
			EnsureDbCreated(serviceProvider);
		}
		
		private void EnsureDbCreated(IServiceProvider serviceProvider)
		{
			var eTrainerDb = serviceProvider.GetRequiredService<ETrainerDbContext>();
			if (eTrainerDb.Database.GetPendingMigrations().Any())
			{
				eTrainerDb.Database.Migrate();
			}

			var eTrainerIdentityDb = serviceProvider.GetRequiredService<ETrainerIdentityDbContext>();
			if (eTrainerIdentityDb.Database.GetPendingMigrations().Any())
			{
				eTrainerIdentityDb.Database.Migrate();
			}
		}
		
		
	}
}
