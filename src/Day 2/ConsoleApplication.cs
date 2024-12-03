namespace Day2;

internal class ConsoleApplication
{
    private readonly IReadLevels _readLevels;
    private readonly IReactor _reactor;
    public ConsoleApplication(IReadLevels readLevels, IReactor reactor)
    {
        _readLevels = readLevels;
        _reactor = reactor;
    }

    public void Run()
    {
        var reports = _readLevels.ReadReportsFromFile("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay2.txt");
        Console.WriteLine("Reports Found: " + reports.Count());


        var safeReports = _reactor.CountSafeReactors(reports);
        Console.WriteLine("Safe Reports Found: " + safeReports); //402

        var safeWithDampner = _reactor.CountSafeReactorsUsingProblemDampner(reports);
        Console.WriteLine("Safe Reports With Dampner: " + safeWithDampner); //455
    }
}
