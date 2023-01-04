using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MijnCV_API.Controllers;
using MijnCV_API.Models;
using MijnCV_API.Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnCV_API.Test
{
    public class SectionTest
    {
        private readonly SectionsController _controller;
        private readonly SectionServiceFake _service;
        public SectionTest()
        {
            _service = new SectionServiceFake();
            _controller = new SectionsController(_service);
        }

        [Fact]
        public void GetAllSectionsTest()
        {
            var expected = new List<Section>()
            {
                new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test1", Position = 1, Title="Test1"},
                new Section() { ID = 2, CV = "TestCV2", Layout = 2, PageID = 2, Paragraph="Dit is een test2", Position = 1, Title="Test2"},
                new Section() { ID = 3, CV = "TestCV3", Layout = 1, PageID = 1, Paragraph="Dit is een test3", Position = 2, Title="Test3"},
            };
            var Result = _controller.GetSections();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Section>>>>(Result);
            Result.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void GetSectionsTest()
        {
            Section expected = new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph = "Dit is een test1", Position = 1, Title = "Test1" };
            var Result = _controller.GetSection(1);

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Section>>>(Result);
            Result.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void DeleteSectionTest()
        {
            var expected = new List<Section>()
            {
                new Section() { ID = 2, CV = "TestCV2", Layout = 2, PageID = 2, Paragraph="Dit is een test2", Position = 1, Title="Test2"},
                new Section() { ID = 3, CV = "TestCV3", Layout = 1, PageID = 1, Paragraph="Dit is een test3", Position = 2, Title="Test3"},
            };

            var result = _service.DeleteSection(1);
            var test = _controller.GetSections();

            Assert.IsType<Task<bool>>(result);
            test.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void PutSectionTest()
        {
            Section expected = new Section() { ID = 1, CV = "TestCV1", Layout = 2, PageID = 1, Paragraph = "Dit is een test1", Position = 1, Title = "Test1Test" };
            Section section = new Section() { CV = "TestCV1", Layout = 2, PageID = 1, Paragraph = "Dit is een test1", Position = 1, Title = "Test1Test" };

            var Result = _service.PutSection(1, section);
            var Result2 = _controller.GetSection(1);

            Assert.NotNull(Result);
            Assert.IsType<Task<bool>>(Result);
            Result2.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void PostSectionTest()
        {
            var expected = new List<Section>()
            {
                new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test1", Position = 1, Title="Test1"},
                new Section() { ID = 2, CV = "TestCV2", Layout = 2, PageID = 2, Paragraph="Dit is een test2", Position = 1, Title="Test2"},
                new Section() { ID = 3, CV = "TestCV3", Layout = 1, PageID = 1, Paragraph="Dit is een test3", Position = 2, Title="Test3"},
                new Section() { ID = 4, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test4", Position = 2, Title="Test4"},
            };

            Section section = new Section() { ID = 4, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph = "Dit is een test4", Position = 2, Title = "Test4" };

            var result = _service.PostSection(section);
            var test = _controller.GetSections();

            Assert.IsType<Task<Section>>(result);
            test.Result.Value.Should().Equals(expected);
        }

        [Fact]
        public void GetSectionsByCv()
        {
            var expected = new List<Section>()
            {
                new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test1", Position = 1, Title="Test1"},
            };
            var Result = _controller.GetSectionsByCV("TestCV1");

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Section>>>>(Result);
            Result.Result.Value.Should().Equals(expected);
        }
    }
}
