using FileParse.Model;
using System.Collections.Specialized;

namespace FileParse;

public class ReadCollectionsFromFile : IReadCollectionsFromFile
{
    public List<Row> ReadFileContentsToCollection(string fileName, string separator)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("File name cannot be null or empty", nameof(fileName));
        }

        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("File not found", fileName);
        }

        var lines = File.ReadAllLines(fileName);

        if (lines.Length == 0)
        {
            throw new InvalidOperationException("File is empty");
        }

        var rowNumber = 0;
        var rows = new List<Row>();
        foreach (var line in lines)
        {
            rows.Add(new Row
            {
                Index = rowNumber,
                Values = ParseLine(line, separator)
            });

            rowNumber++;
        }

        return rows;
    }
    internal StringCollection ParseLine(string line, string separator)
    {
        if (string.IsNullOrEmpty(line))
        {
            throw new ArgumentException("Cannot be null or empty", nameof(line));
        }
        if (!line.Contains(separator))
        {
            throw new ArgumentException("Line is not in the correct format", nameof(line));
        }
        var entries = line.Split(separator);

        if (entries == null)
        {
            throw new ArgumentException("Line is not in the correct format", nameof(line));
        }

        var returnValues = new StringCollection();

        foreach (var entry in entries)
        {
            returnValues.Add(entry);
        }

        return returnValues;
    }
}