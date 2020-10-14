using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ETrainerWeb.Models;
using ETrainerWeb.Models.Repositories;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using ETrainerWeb.Models.Repositories.WorkoutSettingsRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
		public IActionResult Index(WorkoutSettings settings)
		{
			ViewBag.Muscles = musclesRepository.Muscles;
			return View(settings);
		}

		public IActionResult ShowWorkout(WorkoutSettings settings)
		{
			var workout = Workout.GenerateWorkout(settings, exercisesRepository.Exercises);
			return View(workout);
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
