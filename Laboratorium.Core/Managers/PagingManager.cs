using System.Collections.Generic;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Core.Managers
{
    public class PagingManager
    {
        public Paging GetPaging(int totalRows, int currentPage, int pageSize, int pagesSetSize)
        {
            if (totalRows == 0)
            {
                totalRows = 1;
            }

            var totalPages = totalRows / pageSize + (totalRows % pageSize == 0 ? 0 : 1);
            var totalPagesSets = totalPages / pagesSetSize + (totalPages % pagesSetSize == 0 ? 0 : 1);
            var currentPagesSetIndex = (currentPage - 1) / pagesSetSize + 1;
            var isNextEnabled = currentPagesSetIndex != totalPagesSets;
            var isPreviousEnabled = currentPagesSetIndex != 1;
            var currentPagesSet = new List<int>();
            var pageToAdd = 0;
            for (var i = 1; i <= pagesSetSize && pageToAdd < totalPages; i++)
            {
                pageToAdd = (currentPagesSetIndex - 1) * pagesSetSize + i;
                currentPagesSet.Add(pageToAdd);
            }

            var result = new Paging
            {
                CurrentPage = currentPage,
                IsNextEnabled = isNextEnabled,
                IsPreviousEnabled = isPreviousEnabled,
                Pages = currentPagesSet
            };

            return result;
        }
    }
}
