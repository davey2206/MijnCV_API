using MijnCV_API.Models;

namespace MijnCV_API.Services
{
    public interface IPageService
    {
        public Task<List<Page>> GetPages();
        public Task<Page?> GetPage(int id);
        public Task<bool> PutPage(int id, Page page);
        public Task PostPage(Page page);
        public Task<bool> DeletePage(int id);
        public bool PageExists(int id);
        public Task<List<Page>> GetPagesByCV(string cv);
    }
}
