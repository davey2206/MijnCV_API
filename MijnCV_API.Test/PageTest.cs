using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MijnCV_API.Controllers;
using MijnCV_API.Models;
using MijnCV_API.Test.Services;

namespace MijnCV_API.Test
{
    public class PageTest
    {
        private readonly PagesController _controller;
        private readonly PageServiceFake _service;
        public PageTest()
        {
            _service = new PageServiceFake();
            _controller = new PagesController(_service);
        }

        [Fact]
        public void GetAllPagesTest()
        {
            var expected = new List<Page>()
            {
                new Page() { Id = 1, UserID = 1, Name="Main" },
                new Page() { Id = 2, UserID = 1, Name="Second" },
                new Page() { Id = 3, UserID = 2, Name="Main" },
                new Page() { Id = 4, UserID = 2, Name="Second" },
            };
            var Result = _controller.GetPages();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Page>>>>(Result);
            Result.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void GetPagesTest()
        {
            Page expected = new Page() { Id = 1, UserID = 1, Name = "Main" };
            var Result = _controller.GetPage(1);

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Page>>>(Result);
            Result.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void DeletePageTest()
        {
            var expected = new List<Page>()
            {
                new Page() { Id = 2, UserID = 1, Name="Second" },
                new Page() { Id = 3, UserID = 2, Name="Main" },
                new Page() { Id = 4, UserID = 2, Name="Second" },
            };

            var result = _service.DeletePage(1);
            var test = _controller.GetPages();

            Assert.IsType<Task<bool>>(result);
            test.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void PutPageTest()
        {

        }

        [Fact]
        public void PostPageTest()
        {
            var expected = new List<Page>()
            {
                new Page() { Id = 1, UserID = 1, Name="Main" },
                new Page() { Id = 2, UserID = 1, Name="Second" },
                new Page() { Id = 3, UserID = 2, Name="Main" },
                new Page() { Id = 4, UserID = 2, Name="Second" },
                new Page() { Id = 5, UserID = 3, Name="Main" },
            };

            Page page = new Page() { UserID = 3, Name = "Main" };

            var result = _service.PostPage(page);
            var test = _controller.GetPages();

            Assert.IsType<Task<Page>>(result);
            test.Result.Value.Should().Equals(expected);
        }
    }
}
