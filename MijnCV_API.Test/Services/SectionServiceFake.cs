﻿using MijnCV_API.Models;
using MijnCV_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnCV_API.Test.Services
{
    internal class SectionServiceFake : ISectionService
    {
        private readonly List<Section> _sectionCart;

        public SectionServiceFake()
        {
            _sectionCart = new List<Section>()
            {
                new Section() { ID = 1, CV = "TestCV1", Layout = 1, PageID = 1, Paragraph="Dit is een test1", Position = 1, Title="Test1"},
                new Section() { ID = 2, CV = "TestCV2", Layout = 2, PageID = 2, Paragraph="Dit is een test2", Position = 1, Title="Test2"},
                new Section() { ID = 3, CV = "TestCV3", Layout = 1, PageID = 1, Paragraph="Dit is een test3", Position = 2, Title="Test3"},
            };
        }

        public Task<bool> DeleteSection(int id)
        {
            var Section = _sectionCart.First(s => s.ID == id);
            if (Section == null)
            {
                return Task.FromResult(true);
            }

            _sectionCart.Remove(Section);

            return Task.FromResult(false);
        }

        public Task<Section?> GetSection(int id)
        {
            var Section = _sectionCart.Where(s => s.ID == id).FirstOrDefault();
            return Task.FromResult(Section);
        }

        public Task<List<Section>> GetSections()
        {
            return Task.FromResult(_sectionCart);
        }

        public bool SectionExists(int id)
        {
            return _sectionCart.Any(s => s.ID == id);
        }

        public Task PostSection(Section Section)
        {
            Section.ID = _sectionCart.Last().ID + 1;
            _sectionCart.Add(Section);
            return Task.FromResult(Section);
        }

        public Task<bool> PutSection(int id, Section Section)
        {
            if (!SectionExists(id))
            {
                return Task.FromResult(true);
            }

            _sectionCart.First(s => s.ID == id).CV = Section.CV;
            _sectionCart.First(s => s.ID == id).Layout = Section.Layout;
            _sectionCart.First(s => s.ID == id).PageID = Section.PageID;
            _sectionCart.First(s => s.ID == id).Position = Section.Position;
            _sectionCart.First(s => s.ID == id).Title = Section.Title;

            return Task.FromResult(false);
        }
    }
}