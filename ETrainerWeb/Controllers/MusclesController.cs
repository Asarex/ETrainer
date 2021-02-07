using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DbContexts;
using ETrainerWebAPI.Models.DTO;

namespace ETrainerWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MusclesController : ControllerBase
	{
		private readonly ETrainerDbContext _context;
		private readonly IMapper _mapper;

		public MusclesController(ETrainerDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<LocalizedMuscle>>> GetMuscles(int languageId, int offset, int limit)
		{
			var language = await _context.AvailableLanguages.FindAsync(languageId);
			if (language is null)
			{
				return NotFound("Language not found");
			}
			return await _context.Muscles
				.OrderBy(m => m.ID)
				.Skip(offset)
				.Take(limit)
				.Select(m => m.MuscleTranslatedInfos.FirstOrDefault(ti => ti.Language == language))
				.Select(m => _mapper.Map<LocalizedMuscle>(m))
				.ToListAsync();
		}

		// GET: api/Muscles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LocalizedMuscle>> GetMuscle(int languageId, int id)
		{
			var language = await _context.AvailableLanguages.FindAsync(languageId);
			var muscle = (await _context.Muscles.FindAsync(id)).MuscleTranslatedInfos.FirstOrDefault(m => m.Language == language);

			if (muscle == null)
			{
				return NotFound();
			}

			return _mapper.Map<LocalizedMuscle>(muscle);
		}

		[HttpPost]
		public async Task<ActionResult<int>> PostMuscle(IEnumerable<LocalizedMuscle> localizedMuscles)
		{
			var muscle = new Muscle();
			foreach (var localizedMuscle in localizedMuscles)
			{
				var language = await _context.Language.FindAsync(localizedMuscle.LanguageId);
				if (language is null)
				{
					return NotFound($"Language with id {localizedMuscle.LanguageId} not found");
				}
				var muscleTranslatedInfo = _mapper.Map<MuscleTranslatedInfo>(localizedMuscle);
				muscleTranslatedInfo.Language = language;
				muscle.MuscleTranslatedInfos.Add(muscleTranslatedInfo);
			}
			await _context.SaveChangesAsync();
			return Ok(muscle.ID);
			//return CreatedAtAction("GetMuscle", new { id = muscle.ID }, muscle);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMuscle(int id)
		{
			var muscle = await _context.Muscles.FindAsync(id);
			if (muscle == null)
			{
				return NotFound();
			}

			_context.Muscles.Remove(muscle);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool MuscleExists(int id)
		{
			return _context.Muscles.Any(e => e.ID == id);
		}
	}
}
