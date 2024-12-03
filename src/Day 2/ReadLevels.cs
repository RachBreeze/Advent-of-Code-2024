using Day2.Model;
using FileParse;
using FileParse.Model;

namespace Day2;

internal sealed class ReadLevels : IReadLevels
{
    private readonly IReadFileContents _readCollectionsFromFile;

    public ReadLevels(IReadFileContents readCollectionsFromFile)
    {
        _readCollectionsFromFile = readCollectionsFromFile;
    }

    public IEnumerable<Report> ReadReportsFromFile(string filename)
    {
        var rows = _readCollectionsFromFile.AsCollections(filename, " ");

        if (rows == null)
        {
            throw new InvalidOperationException("File is empty");
        }

        if (rows.Count == 0)
        {
            throw new InvalidOperationException("File is empty");
        }

        var reports = new List<Report>();

        foreach (var row in rows)
        {
            var report = ParseLine(row);
            if (report != null)
            {
                reports.Add(report);
            }
        }

        return reports;
    }
    private Report ParseLine(Row row)
    {
        if (row == null)
        {
            throw new ArgumentException("Row cannot be null", nameof(row));
        }
        if (row.Values.Count == 0)
        {
            throw new ArgumentException("Row is not in the correct format", nameof(row));
        }

        var report = new Report();

        foreach (var item in row.Values)
        {
            if (!int.TryParse(item, out var level))
            {
                throw new ArgumentException("Level is not an integer", nameof(row));
            }

            report.Levels.Add(level);
        }

        return report;
    }
}

