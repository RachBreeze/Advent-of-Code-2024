using Day1.Model;

namespace Day1;
public class ProcessLocations : IProcessLocations
{
    public Stack<int> GetColumn1OptionsOrderd(IEnumerable<LocationOption> locations)
    {
        return GetStack(locations.Select(l => l.Column1));
    }

    private Stack<int> GetStack(IEnumerable<int> cols)
    {
        return new Stack<int>(cols.OrderDescending());
    }

    public Stack<int> GetColumn2OptionsOrdered(IEnumerable<LocationOption> locations)
    {
        return GetStack(locations.Select(l => l.Column2));
    }
    public int TotalDistance(IEnumerable<LocationOption> locations)
    {
        if (locations == null)
        {
            throw new ArgumentNullException(nameof(locations));
        }

        var locations1 = GetColumn1OptionsOrderd(locations);
        var locations2 = GetColumn2OptionsOrdered(locations);

        if (locations1.Count != locations2.Count)
        {
            throw new InvalidOperationException("Locations are not the same length");
        }

        var distance = 0;

        while (locations1.Count > 0)
        {
            distance += Math.Abs(locations1.Pop() - locations2.Pop());
        }

        return distance;
    }
}
