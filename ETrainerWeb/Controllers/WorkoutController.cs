using System.Collections.Generic;
using System.Linq;
using ETrainerWeb.Models;
using ETrainerWeb.Models.Repositories;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories;
using ETrainerWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Controllers
{
	public class WorkoutController : Controller
	{
		private readonly IMusclesRepository musclesRepository;
		private readonly IExercisesRepository exercisesRepository;
		private readonly IWorkoutSettingsRepository workoutSettingsRepository;

		public WorkoutController(IMusclesRepository mRep, IExercisesRepository eRep, IWorkoutSettingsRepository wRep)
		{
			musclesRepository = mRep;
			exercisesRepository = eRep;
			workoutSettingsRepository = wRep;
		}

		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.Muscles = musclesRepository.Muscles;
			var settings = new WorkoutSettingsViewModel();
			return View(settings);
		}

		[HttpPost]
		public IActionResult Index(WorkoutSettingsViewModel settings)
		{
			ViewBag.Muscles = musclesRepository.Muscles;
			return View(settings);
		}

		public IActionResult ShowWorkout(WorkoutSettingsViewModel settings)
		{
			if (ModelState.IsValid)
			{
				var workoutSettings = new WorkoutSettings();
				workoutSettings.Name = settings.Name;
				workoutSettings.UserName = settings.UserName;
				workoutSettings.IncludeMuscleses = musclesRepository.Muscles
					.Where(m => settings.IncludeMuscleses.Contains(m.ID)).ToList();
				workoutSettings.ExcludeMuscleses = musclesRepository.Muscles
					.Where(m => settings.ExcludeMuscleses.Contains(m.ID)).ToList();
				var workout = Workout.GenerateWorkout(workoutSettings, exercisesRepository.Exercises);
				return View(workout);
			}
			ViewBag.Muscles = musclesRepository.Muscles;
			return View("Index", settings);
		}

		[Authorize]
		public IActionResult SaveWorkoutSettings(WorkoutSettings settings)
		{
			if (ModelState.IsValid)
			{
				workoutSettingsRepository.Add(settings);
				return RedirectToAction("Index", "Home");
			}

			return RedirectToAction("Index");

		}
	}
}
