using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DTO;

namespace ETrainerWebAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly UserManager<ETrainerUser> _userManager;
		private readonly SignInManager<ETrainerUser> _signInManager;
		private readonly IMapper _mapper;

		public UsersController(UserManager<ETrainerUser> userManager, SignInManager<ETrainerUser> signInManager, IMapper mapper)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_mapper = mapper;
		}
		
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Registration([FromBody] UserRegisterInfo registerInfo)
		{
			ETrainerUser eTrainerUser = _mapper.Map<ETrainerUser>(registerInfo);
			// добавляем пользователя
			var result = await _userManager.CreateAsync(eTrainerUser, registerInfo.Password);
			if (result.Succeeded)
			{
				return Ok();
			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(error.Code, error.Description);
			}
			return ValidationProblem(ModelState);
		}

		[HttpGet]
		[Route("Login")]
		public async Task<IActionResult> Login(string login, string password)
		{
			var user = await _userManager.FindByNameAsync(login);
			if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, password, false)).Succeeded)
			{
				return Ok();
			}

			return BadRequest();
		}
	}
}
