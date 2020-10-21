using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETrainerWeb.Models;
using ETrainerWeb.Models.Repositories;
using ETrainerWeb.Models.Repositories.ExercisesRepositories;
using ETrainerWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ETrainerWeb.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly IMusclesRepository musclesRepository;
		private readonly IExercisesRepository exercisesRepository;
		public AdminController(IMusclesRepository musclesRepository, IExercisesRepository exercisesRepository)
		{
			this.musclesRepository = musclesRepository;
			this.exercisesRepository = exercisesRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Muscles()
		{
			return View(musclesRepository.Muscles);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteMuscle(int id)
		{
			var muscle = musclesRepository.Muscles.FirstOrDefault(m => m.ID == id);
			musclesRepository.Delete(muscle);
			return RedirectToAction("Muscles");
		}

		[HttpGet]
		public async Task<IActionResult> EditMuscle(int id)
		{
			var muscle = await musclesRepository.Muscles.FirstOrDefaultAsync(m => m.ID == id) ?? new Muscle();
			return View(muscle);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditMuscle(Muscle muscle)
		{
			if (ModelState.IsValid)
			{
				if (muscle.ID == 0)
				{
					musclesRepository.Add(muscle);
				}
				else
				{
					await musclesRepository.SaveAsync(muscle);
				}

				return RedirectToAction("Muscles", "Admin");
			}
			return View(muscle);
		}


		[HttpGet]
		public IActionResult Exercises()
		{
			return View(exercisesRepository.Exercises);
		}

		public IActionResult DeleteExercise(int id)
		{
			var exercise = exercisesRepository.Exercises.FirstOrDefault(e => e.ID == id);
			exercisesRepository.Delete(exercise);
			return RedirectToAction("Exercises");
		}

		[HttpGet]
		public async Task<IActionResult> EditExercise(int id)
		{
			var exercise = await exercisesRepository.Exercises.FirstOrDefaultAsync(e => e.ID == id) ?? new Exercise();
			var exerciseModel = new EditExerciseViewModel(exercise);
			exerciseModel.AllMuscles = musclesRepository.Muscles.AsNoTracking();
			return View(exerciseModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditExercise(EditExerciseViewModel exerciseModel)
		{
			if (ModelState.IsValid)
			{
				var exercise = new Exercise();
				exercise.ID = exerciseModel.ID;
				exercise.Name = exerciseModel.Name;
				exercise.Description = exerciseModel.Description;
				exercise.UseMuscles = musclesRepository.Muscles.Where(m => exerciseModel.UseMuscles.Contains(m.ID)).ToList();
				if (exercise.ID == 0)
				{
					exercisesRepository.Add(exercise);
				}
				else
				{
					await exercisesRepository.SaveAsync(exercise);
				}

				return RedirectToAction("Exercises", "Admin");
			}
			exerciseModel.AllMuscles = musclesRepository.Muscles.AsNoTracking();
			return View(exerciseModel);
		}
	}
}
