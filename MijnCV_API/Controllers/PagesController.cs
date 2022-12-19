using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MijnCV_API.Models;
using MijnCV_API.Services;
using static System.Collections.Specialized.BitVector32;

namespace MijnCV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _PageService;

        public PagesController(IPageService service)
        {
            _PageService = service;
        }

        // GET: api/Pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await _PageService.GetPages();
        }

        // GET: api/Pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await _PageService.GetPage(id);

            if (page == null)
            {
                return NotFound();
            }

            return page;
        }

        // PUT: api/Pages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPage(int id, Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }

            if (_PageService.PutPage(id, page).Result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Pages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage(Page page)
        {
            await _PageService.PostPage(page);

            return CreatedAtAction("GetPage", new { id = page.Id }, page);
        }

        // DELETE: api/Pages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePage(int id)
        {
            if (_PageService.DeletePage(id).Result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
