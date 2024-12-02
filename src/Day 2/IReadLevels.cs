using Day2.Model;

namespace Day2;

internal interface IReadLevels
{
    public IEnumerable<Report> ReadReportsFromFile(string filename);
}