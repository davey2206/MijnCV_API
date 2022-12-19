using MijnCV_API.Models;

namespace MijnCV_API.Services
{
    public interface ISectionService
    {
        public Task<List<Section>> GetSections();
        public Task<Section?> GetSection(int id);
        public Task<bool> PutSection(int id, Section section);
        public Task PostSection(Section section);
        public Task<bool> DeleteSection(int id);
        public bool SectionExists(int id);
    }
}
