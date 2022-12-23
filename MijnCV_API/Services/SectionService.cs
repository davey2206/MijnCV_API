using Microsoft.EntityFrameworkCore;
using MijnCV_API.Models;

namespace MijnCV_API.Services
{
    public class SectionService : ISectionService
    {
        private readonly MijnCVContext _context;
        public SectionService(MijnCVContext context)
        {
            _context = context;
        }

        public async Task<List<Section>> GetSections()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<Section?> GetSection(int id)
        {
            return await _context.Sections.FindAsync(id);
        }

        public Task<bool> PutSection(int id, Section section)
        {
            _context.Entry(section).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(id))
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

        public async Task PostSection(Section section)
        {
            _context.Sections.Add(section);
            await _context.SaveChangesAsync();
        }

        public Task<bool> DeleteSection(int id)
        {
            var section = _context.Sections.Find(id);
            if (section == null)
            {
                return Task.FromResult(true);
            }

            _context.Sections.Remove(section);
            _context.SaveChanges();

            return Task.FromResult(false);
        }

        public bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.ID == id);
        }

        public async Task<List<Section>> GetSectionsByCV(string cv)
        {
            return await _context.Sections.Where(s => s.CV == cv).ToListAsync();
        }
    }
}
