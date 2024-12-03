namespace Day1;

internal sealed class ConsoleApplication
{
    private readonly IReadLocations _readLocations;
    private readonly IProcessLocations _processLocations;

    public ConsoleApplication(IReadLocations readLocations, IProcessLocations processLocations)
    {
        _readLocations = readLocations;
        _processLocations = processLocations;
    }

    public void Run()
    {
        var locations = _readLocations.ReadLocationsFromFile("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay1.txt");
        Console.WriteLine("Locations Found: " + locations.Column1Options.Count());

        var distance = _processLocations.Part1(locations);

        Console.WriteLine("Distance: " + distance); //1830467

        var similarityScore = _processLocations.Part2(locations);

        Console.WriteLine("Similarity Score: " + similarityScore); //26674158
    }
}
