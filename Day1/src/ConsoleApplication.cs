namespace Day1;

internal class ConsoleApplication
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
        var locations = _readLocations.ReadLocationsFromFile("C:\\GitHub\\Advent-Of-Code-2024\\Day1\\data\\input.txt");
        Console.WriteLine("Locations Found: " + locations.Column1Options.Count());

        var distance = _processLocations.TotalDistance(locations);

        Console.WriteLine("Distance: " + distance); //1830467

        var similarityScore = _processLocations.TotalSimilarityScore(locations);

        Console.WriteLine("Similarity Score: " + similarityScore);
    }
}
