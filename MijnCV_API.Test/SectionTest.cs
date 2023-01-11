using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MijnCV_API.Controllers;
using MijnCV_API.Models;
using MijnCV_API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnCV_API.Test
{
    public class SectionTest
    {
        private readonly Mock<ISectionService> _service;
        public SectionTest()
        {
            _service = new Mock<ISectionService>();
        }

        [Fact]
        public void GetAllSectionsTest()
        {
            var data = GetSectionsData();
            _service.Setup(x => x.GetSections()).Returns(async () => data);
            var controller = new SectionsController(_service.Object);

            var Result = controller.GetSections();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Section>>>>(Result);
            Result.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void GetSectionsTest()
        {
            var data = GetSectionsData();
            _service.Setup(x => x.GetSection(1)).Returns(async () => data[0]);
            var controller = new SectionsController(_service.Object);

            var Result = controller.GetSection(1);

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Section>>>(Result);
            Result.Result.Value.Should().Equals(data[0]);
        }

        [Fact]
        public void DeleteSectionTest()
        {
            var data = GetSectionsData();
            _service.Setup(x => x.DeleteSection(1)).Returns(async () => true);
            var controller = new SectionsController(_service.Object);

            var Result = controller.DeleteSection(1);
            var Result2 = controller.GetSections();

            Assert.NotNull(Result);
            Result2.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void PutSectionTest()
        {
            Section section = new Section() { CV = "TestCV1", Layout = 2, PageID = 1, Paragraph = "Dit is een test1", Position = 1, Title = "Test1Test" };

            var data = GetSectionsData();
            _service.Setup(x => x.PutSection(1, section)).Returns(async () => true);
            var controller = new SectionsController(_service.Object);

            var Result = controller.PutSection(1, section);
            var Result2 = controller.GetSection(1);

            Assert.NotNull(Result);
            Result2.Result.Value.Should().Equals(data[0]);
        }

        [Fact]
        public void PostSectionTest()
        {
            Section section = new Section() { ID = 4, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph = "Dit is een test4", Position = 2, Title = "Test4" };

            var data = GetSectionsData();
            _service.Setup(x => x.PostSection(section)).Returns(async () => data);
            var controller = new SectionsController(_service.Object);

            var Result = controller.PostSection(section);
            var Result2 = controller.GetSections();

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<Section>>>(Result);
            Result2.Result.Value.Should().Equals(data);
        }

        [Fact]
        public void GetSectionsByCv()
        {
            var data = GetSectionsData();
            _service.Setup(x => x.GetSectionsByCV("TestCV1")).Returns(async () => data);
            var controller = new SectionsController(_service.Object);

            var Result = controller.GetSectionsByCV("TestCV1");

            Assert.NotNull(Result);
            Assert.IsType<Task<ActionResult<IEnumerable<Section>>>>(Result);
            Result.Result.Value.Should().Equals(data);
        }

        public List<Section> GetSectionsData()
        {
            List<Section> sections = new List<Section>()
            {
                new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test1", Position = 1, Title="Test1"},
                new Section() { ID = 2, CV = "TestCV2", Layout = 2, PageID = 2, Paragraph="Dit is een test2", Position = 1, Title="Test2"},
                new Section() { ID = 3, CV = "TestCV3", Layout = 1, PageID = 1, Paragraph="Dit is een test3", Position = 2, Title="Test3"},
            };

            return sections;
        }
    }
}
