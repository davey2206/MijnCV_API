using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MijnCV_API.Controllers;
using MijnCV_API.Models;
using MijnCV_API.Services;

namespace MijnCV_API.Test
{
    public class PageTest
    {
        private readonly Mock<IPageService> _service;
        public PageTest()
        {
            _service = new Mock<IPageService>();
        }

        [Fact]
        public void GetAllPagesTest()
        {
            var data = GetPagesData();
            _service.Setup(x => x.GetPages()).Returns(async () => data);
            var controller = new PagesController(_service.Object);

            var Result = controller.GetPages();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Page>>>>(Result);
            Result.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void GetPagesTest()
        {
            var data = GetPagesData();
            _service.Setup(x => x.GetPage(1)).Returns(async () => data[0]);
            var controller = new PagesController(_service.Object);

            var Result = controller.GetPage(1);

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Page>>>(Result);
            Result.Result.Value.Should().Equals(data[0]);
        }

        [Fact]
        public void DeletePageTest()
        {
            var data = GetPagesData();
            _service.Setup(x => x.DeletePage(1)).Returns(async () => true);
            var controller = new PagesController(_service.Object);

            var Result = controller.DeletePage(1);
            var Result2 = controller.GetPages();

            Assert.NotNull(Result);
            Result2.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void PutPageTest()
        {
            Page page = new Page() { cv = "1", Name = "Main2" };

            var data = GetPagesData();
            _service.Setup(x => x.PutPage(1, page)).Returns(async () => true);
            var controller = new PagesController(_service.Object);

            var Result = controller.PutPage(1, page);
            var Result2 = controller.GetPage(1);

            Assert.NotNull(Result);
            Result2.Result.Value.Should().Equals(data[0]);
        }

        [Fact]
        public void PostPageTest()
        {
            Page page = new Page() { cv = "3", Name = "Main" };

            var data = GetPagesData();
            _service.Setup(x => x.PostPage(page)).Returns(async () => data);
            var controller = new PagesController(_service.Object);

            var Result = controller.PostPage(page);
            var Result2 = controller.GetPages();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Page>>>(Result);
            Result2.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void GetPagesByCvTest()
        {
            var data = GetPagesData();
            _service.Setup(x => x.GetPagesByCV("1")).Returns(async () => data);
            var controller = new PagesController(_service.Object);

            var Result = controller.GetPagesByCV("1");

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Page>>>>(Result);
            Result.Result.Value.Should().Equals(data);
        }

        public List<Page> GetPagesData()
        {
            List<Page> pages = new List<Page>()
            {
                new Page() { Id = 1, cv = "1", Name="Main" },
                new Page() { Id = 2, cv = "1", Name="Second" },
                new Page() { Id = 3, cv = "2", Name="Main" },
                new Page() { Id = 4, cv = "2", Name="Second" },
            };
            return pages;
        }
    }
}
