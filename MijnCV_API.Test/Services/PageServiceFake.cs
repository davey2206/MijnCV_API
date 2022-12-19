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
        private readonly List<Page> _pageCart;

        public PageServiceFake()
        {
            _pageCart = new List<Page>()
            {
                new Page() { Id = 1, UserID = 1, Name="Main" },
                new Page() { Id = 2, UserID = 1, Name="Second" },
                new Page() { Id = 3, UserID = 2, Name="Main" },
                new Page() { Id = 4, UserID = 2, Name="Second" },
            };
        }

        public Task<bool> DeletePage(int id)
        {
            var page = _pageCart.First(p => p.Id == id);
            if (page == null)
            {
                return Task.FromResult(true);
            }

            _pageCart.Remove(page);

            return Task.FromResult(false);
        }

        public Task<Page?> GetPage(int id)
        {
            var page = _pageCart.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(page);
        }

        public Task<List<Page>> GetPages()
        {
            return Task.FromResult(_pageCart);
        }

        public bool PageExists(int id)
        {
            return _pageCart.Any(p => p.Id == id);
        }

        public Task PostPage(Page page)
        {
            page.Id = _pageCart.Last().Id + 1;
            _pageCart.Add(page);
            return Task.FromResult(page);
        }

        public Task<bool> PutPage(int id, Page page)
        {
            if (!PageExists(id))
            {
                return Task.FromResult(true);
            }

            _pageCart.First(p => p.Id == id).Name = page.Name;
            _pageCart.First(p => p.Id == id).UserID = page.UserID;

            return Task.FromResult(false);
        }
    }
}
