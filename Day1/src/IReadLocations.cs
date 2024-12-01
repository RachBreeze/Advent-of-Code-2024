using Day1.Model;

namespace Day1;

internal interface IReadLocations
{
    IEnumerable<LocationOption> ReadLocationsFromFile(string fileName);
}