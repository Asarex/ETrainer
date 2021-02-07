using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ETrainerWebAPI.Models;
using ETrainerWebAPI.Models.DbContexts;
using ETrainerWebAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace ETrainerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableLanguagesController : ControllerBase
    {
        private readonly ETrainerDbContext _context;
        private readonly IMapper _mapper;

        public AvailableLanguagesController(ETrainerDbContext context, IMapper mapper)
        {
	        _context = context;
	        _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageInfo>>> GetLanguage()
        {
            return await _context.Language.Select(l => _mapper.Map<LanguageInfo>(l)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageInfo>> GetLanguage(int id)
        {
            var language = await _context.Language.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return _mapper.Map<LanguageInfo>(language);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutLanguage(int id, [FromBody] LanguageInfo languageInfo)
        {
            if (id != languageInfo.LanguageId)
            {
                return BadRequest();
            }

            var language = _mapper.Map<Language>(languageInfo);
            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<LanguageInfo>> PostLanguage([FromBody] LanguageInfo languageInfo)
        {
	        var language = _mapper.Map<Language>(languageInfo);
            await _context.Language.AddAsync(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguage", new { id = language.ID }, language);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            var language = await _context.Language.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Language.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(int id)
        {
            return _context.Language.Any(e => e.ID == id);
        }
    }
}
