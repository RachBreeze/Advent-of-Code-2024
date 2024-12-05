namespace Day5.Model;
internal sealed class PageOrderPairs
{
    public int PageNumber1 { get; set; }
    public int PageNumber2 { get; set; }

    public override bool Equals(object obj)
    {
        var item = obj as PageOrderPairs;

        if (item == null)
        {
            return false;
        }
        return item.PageNumber1 == PageNumber1 && item.PageNumber2 == PageNumber2;
    }
}

