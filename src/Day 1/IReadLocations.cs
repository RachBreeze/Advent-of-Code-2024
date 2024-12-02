using Day1.Model;

namespace Day1;

internal interface IReadLocations
{
    LocationOptions ReadLocationsFromFile(string fileName);
}