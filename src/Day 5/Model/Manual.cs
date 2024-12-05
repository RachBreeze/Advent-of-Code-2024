namespace Day5.Model;

internal sealed class Manual
{
    private readonly List<int> _pages;
    public Manual()
    {
        _pages = new List<int>();
    }

    public Manual(List<int> pages)
    {
        _pages = pages;
    }
    public void AddPage(int page)
    {
        _pages.Add(page);
    }

    public IEnumerable<int> Pages => _pages;
}

