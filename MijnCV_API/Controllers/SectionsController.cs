using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MijnCV_API.Models;
using MijnCV_API.Services;

namespace MijnCV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly ISectionService _SectionService;

        public SectionsController(ISectionService service)
        {
            _SectionService = service;
        }

        // GET: api/Sections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetSections()
        {
            return await _SectionService.GetSections();
        }

        // GET: api/Sections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetSection(int id)
        {
            var section = await _SectionService.GetSection(id);

            if (section == null)
            {
                return NotFound();
            }

            return section;
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSection(int id, Section section)
        {
            if (id != section.ID)
            {
                return BadRequest();
            }

            if (_SectionService.PutSection(id, section).Result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Section>> PostSection(Section section)
        {
            await _SectionService.PostSection(section);

            return CreatedAtAction("GetSection", new { id = section.ID }, section);
        }

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            if (_SectionService.DeleteSection(id).Result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("CV/{cv}")]
        public async Task<ActionResult<IEnumerable<Section>>> GetSectionsByCV(string cv)
        {
            return await _SectionService.GetSectionsByCV(cv);
        }
    }
}
