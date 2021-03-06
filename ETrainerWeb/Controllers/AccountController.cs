﻿using System.Threading.Tasks;
using Castle.Core.Internal;
using ETrainerWeb.Models;
using ETrainerWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ETrainerWeb.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Registration(string returnUrl)
		{
			var model = new RegistrationViewModel {ReturnUrl = returnUrl};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration(RegistrationViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User { Email = model.Email, UserName = model.Name};
				// добавляем пользователя
				var result = await userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					// установка куки
					await signInManager.SignInAsync(user, false);
					return model.ReturnUrl.IsNullOrEmpty() ? (IActionResult)RedirectToAction("Index", "Home") : Redirect(model.ReturnUrl);
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				
			}
			return View(model);
		}

		public IActionResult Login(string returnUrl)
		{
			var model = new LoginViewModel {ReturnUrl = returnUrl};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result =
					await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
					{
						return Redirect(model.ReturnUrl);
					}
				
					return model.ReturnUrl.IsNullOrEmpty() ? (IActionResult)RedirectToAction("Index", "Home") : Redirect(model.ReturnUrl);
				}

				ModelState.AddModelError("", "Неправильный логин и (или) пароль");
			}
			return View(model);
		}
		
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
