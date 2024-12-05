using Day5.Model;
using System.Collections.Specialized;

namespace Day5;

internal sealed class Parser : IParser
{
    public int Part1(StringCollection input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        if (input.Count == 0)
        {
            return 0;
        }

        var pageOrdering = ReadPageOrdering(input);
        var pages = ReadManuals(input);
        var total = 0;
        foreach (var page in pages)
        {
            if (IsValidManual(page, pageOrdering))
            {
                total += GetMiddlePage(page);
            }
        }
        return total;

    }

    internal protected int GetMiddlePage(Manual page)
    {
        if (page == null)
        {
            throw new ArgumentNullException(nameof(page));
        }

        var pages = page.Pages;

        if (pages.Count() == 0)
        {
            return 0;
        }

        if (pages.Count() == 1)
        {
            return pages.First();
        }

        return pages.ElementAt(pages.Count() / 2);
    }

    internal protected bool IsValidManual(Manual page, IEnumerable<PageOrderPairs> pageOrdering)
    {
        if (page == null)
        {
            throw new ArgumentNullException(nameof(page));
        }
        if (pageOrdering == null)
        {
            throw new ArgumentNullException(nameof(pageOrdering));
        }
        var pageCount = page.Pages.Count();
        var previousPages = new List<int>();

        for (int i = 0; i < pageCount; i++)
        {
            var currentPage = page.Pages.ElementAt(i);
            var pageOrder = pageOrdering.Where(x => x.PageNumber1 == currentPage);

            foreach (var order in pageOrder)
            {
                if (previousPages.Contains(order.PageNumber2))
                {
                    return false;
                }
            }
            previousPages.Add(page.Pages.ElementAt(i));
        }

        return true;
    }

    internal protected IEnumerable<PageOrderPairs> ReadPageOrdering(StringCollection input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }


        var pageOrdering = new List<PageOrderPairs>();
        if (input.Count == 0)
        {
            return pageOrdering;
        }


        foreach (var item in input)
        {
            if (!string.IsNullOrEmpty(item))
            {
                var pageOrder = item.Split('|');
                if (pageOrder.Length != 2)
                {
                    throw new Exception("Invalid page ordering " + item);
                }
                if (!int.TryParse(pageOrder[0], out int pageNumber1))
                {
                    throw new ArgumentException("Invalid page number " + pageOrder[0] + " for " + item);
                }
                if (!int.TryParse(pageOrder[1], out int pageNumber2))
                {
                    throw new ArgumentException("Invalid page number " + pageOrder[1] + " for " + item);
                }
                pageOrdering.Add(new PageOrderPairs
                {
                    PageNumber1 = pageNumber1,
                    PageNumber2 = pageNumber2
                }
                );
            }
            else
            {
                return pageOrdering;
            }
        }

        return pageOrdering;
    }
    internal protected IEnumerable<Manual> ReadManuals(StringCollection input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        var manuals = new List<Manual>();
        if (input.Count == 0)
        {
            return manuals;
        }

        foreach (var item in input)
        {
            var manual = ReadManual(item);
            if (manual != null)
            {
                manuals.Add(manual);
            }
        }

        return manuals;
    }

    internal protected Manual ReadManual(string item)
    {
        if (string.IsNullOrEmpty(item))
        {
            return null;
        }

        if (!item.Contains(","))
        {
            return null;
        }

        var manual = new Manual();

        var pages = item.Split(',');

        foreach (var page in pages)
        {
            if (!int.TryParse(page, out var pageNumber))
            {
                throw new ArgumentException("Invalid page number " + page + " for " + item);
            }
            manual.AddPage(pageNumber);
        }

        return manual;
    }
}
