using System.Collections.Generic;
using System.Xml;
using FluentAssertions;
using Laboratorium.Core.Managers;
using Laboratorium.Models.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests
{
    [TestClass]
    public class PagingManagerTest
    {
        private PagingManager _pagingManager;

        [TestInitialize]
        public void Initialize()
        {
            _pagingManager = new PagingManager();
        }

        [TestMethod]
        public void ZeroRows_OnePageArrowsAreDisabled()
        {
            var expected = new Paging
            {
                CurrentPage = 1,
                IsNextEnabled = false,
                IsPreviousEnabled = false,
                Pages = new List<int> {1}
            };

            int totalRows = 0;
            int currentPage = 1;
            int pageSize = 2;
            int pagesSetSize = 2;

            var actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
        }

        [TestMethod]
        public void NotFullOnePage_OnePageArrowsAreDisabled()
        {
            var expected = new Paging
            {
                CurrentPage = 1,
                IsNextEnabled = false,
                IsPreviousEnabled = false,
                Pages = new List<int> { 1 }
            };

            int totalRows = 1;
            int currentPage = 1;
            int pageSize = 2;
            int pagesSetSize = 2;

            var actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
        }

        [TestMethod]
        public void FullOnePage_OnePageArrowsAreDisabled()
        {
            var expected = new Paging
            {
                CurrentPage = 1,
                IsNextEnabled = false,
                IsPreviousEnabled = false,
                Pages = new List<int> { 1 }
            };

            int totalRows = 2;
            int currentPage = 1;
            int pageSize = 2;
            int pagesSetSize = 2;

            var actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
        }

        [TestMethod]
        public void TwoFullPages_OnePageArrowsAreDisabled()
        {
            var expected = new Paging
            {
                CurrentPage = 1,
                IsNextEnabled = false,
                IsPreviousEnabled = false,
                Pages = new List<int> { 1, 2 }
            };

            int totalRows = 4;
            int currentPage = 1;
            int pageSize = 2;
            int pagesSetSize = 2;

            var actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
            actual.Pages[1].Should().Be(expected.Pages[1]);

            expected.CurrentPage = 2;
            currentPage = 2;

            actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
            actual.Pages[1].Should().Be(expected.Pages[1]);
        }

        [TestMethod]
        public void ThreePages_TwoFirstPagesLeftArrowIsDisabledRightArrowIsEnabled()
        {
            var expected = new Paging
            {
                CurrentPage = 1,
                IsNextEnabled = true,
                IsPreviousEnabled = false,
                Pages = new List<int> { 1, 2 }
            };

            int totalRows = 5;
            int currentPage = 1;
            int pageSize = 2;
            int pagesSetSize = 2;

            var actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
            actual.Pages[1].Should().Be(expected.Pages[1]);


            currentPage = 2;
            expected.CurrentPage = 2;
            actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
            actual.Pages[1].Should().Be(expected.Pages[1]);

            currentPage = 3;
            expected = new Paging
            {
                CurrentPage = currentPage,
                IsNextEnabled = false,
                IsPreviousEnabled = true,
                Pages = new List<int> {3}
            };
            actual = _pagingManager.GetPaging(totalRows, currentPage, pageSize, pagesSetSize);

            actual.CurrentPage.Should().Be(expected.CurrentPage);
            actual.IsNextEnabled.Should().Be(expected.IsNextEnabled);
            actual.IsPreviousEnabled.Should().Be(expected.IsPreviousEnabled);
            actual.Pages.Count.Should().Be(expected.Pages.Count);
            actual.Pages[0].Should().Be(expected.Pages[0]);
        }
    }
}
