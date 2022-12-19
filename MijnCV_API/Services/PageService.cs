using Microsoft.EntityFrameworkCore;
using MijnCV_API.Models;

namespace MijnCV_API.Services
{
    public class PageService : IPageService
    {
        private readonly MijnCVContext _context;
        public PageService(MijnCVContext context)
        {
            _context = context;
        }

        public async Task<List<Page>> GetPages()
        {
            return await _context.Pages.ToListAsync();
        }

        public async Task<Page?> GetPage(int id)
        {
            return await _context.Pages.FindAsync(id);
        }

        public Task<bool> PutPage(int id, Page page)
        {
            _context.Entry(page).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(id))
                {
                    return Task.FromResult(true);
                }
                else
                {
                    throw;
                }
            }

            return Task.FromResult(false);
        }

        public async Task PostPage(Page page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
        }

        public Task<bool> DeletePage(int id)
        {
            var page = _context.Pages.Find(id);
            if (page == null)
            {
                return Task.FromResult(true);
            }

            _context.Pages.Remove(page);
            _context.SaveChanges();

            return Task.FromResult(false);
        }

        public bool PageExists(int id)
        {
            return _context.Pages.Any(e => e.Id == id);
        }
    }
}
