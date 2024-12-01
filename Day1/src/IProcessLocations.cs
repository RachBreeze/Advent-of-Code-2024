using Day1.Model;

namespace Day1;

public interface IProcessLocations
{
    int TotalDistance(IEnumerable<LocationOption> locations);
}