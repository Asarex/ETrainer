using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ETrainerWeb.Models;
using ETrainerWeb.Models.Repositories;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETrainerWeb.Controllers
{
	public class WorkoutController : Controller
	{
		private readonly IMusclesRepository musclesRepository;
		private readonly IExercisesRepository exercisesRepository;
		public WorkoutController(IMusclesRepository mRep, IExercisesRepository eRep)
		{
			musclesRepository = mRep;
			exercisesRepository = eRep;
		}
		public IActionResult Index()
		{
			var settings = new WorkoutSettings();
			ViewBag.Muscles = new SelectList(musclesRepository.Muscles.Select(m => m.Name));
			return View(settings);
		}

		public IActionResult ShowWorkout(WorkoutSettings settings)
		{
			var workout = Workout.GenerateWorkout(settings, exercisesRepository.Exercises);
			return View(workout);
		}
	}
}
