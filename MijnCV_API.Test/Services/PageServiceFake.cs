using Microsoft.EntityFrameworkCore;
using MijnCV_API.Models;
using MijnCV_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnCV_API.Test.Services
{
    internal class PageServiceFake : IPageService
    {
        private readonly List<Page> _page;

        public PageServiceFake()
        {
            _page = new List<Page>()
            {
                new Page() { Id = 1, cv = "1", Name="Main" },
                new Page() { Id = 2, cv = "1", Name="Second" },
                new Page() { Id = 3, cv = "2", Name="Main" },
                new Page() { Id = 4, cv = "2", Name="Second" },
            };
        }

        public Task<bool> DeletePage(int id)
        {
            var page = _page.First(p => p.Id == id);
            if (page == null)
            {
                return Task.FromResult(true);
            }

            _page.Remove(page);

            return Task.FromResult(false);
        }

        public Task<Page?> GetPage(int id)
        {
            var page = _page.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(page);
        }

        public Task<List<Page>> GetPages()
        {
            return Task.FromResult(_page);
        }

        public bool PageExists(int id)
        {
            return _page.Any(p => p.Id == id);
        }

        public Task PostPage(Page page)
        {
            page.Id = _page.Last().Id + 1;
            _page.Add(page);
            return Task.FromResult(page);
        }

        public Task<bool> PutPage(int id, Page page)
        {
            if (!PageExists(id))
            {
                return Task.FromResult(true);
            }

            _page.First(p => p.Id == id).Name = page.Name;
            _page.First(p => p.Id == id).cv = page.cv;

            return Task.FromResult(false);
        }

        public Task<List<Page>> GetPagesByCV(string cv)
        {
            throw new NotImplementedException();
        }
    }
}
