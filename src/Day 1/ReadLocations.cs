using Day1.Model;
using FileParse;
using FileParse.Model;

namespace Day1;

internal class ReadLocations : IReadLocations
{
    private readonly IReadFileContents _readCollectionsFromFile;
    public ReadLocations(IReadFileContents readCollectionsFromFile)
    {
        _readCollectionsFromFile = readCollectionsFromFile;
    }

    public LocationOptions ReadLocationsFromFile(string fileName)
    {
        var rows = _readCollectionsFromFile.AsCollections(fileName, Constants.LOCATION_SEPERATION);

        if (rows == null)
        {
            throw new InvalidOperationException("File is empty");
        }
        if (rows.Count == 0)
        {
            throw new InvalidOperationException("File is empty");
        }

        var locations = new LocationOptions();
        foreach (var row in rows)
        {
            var location = ParseLine(row);
            if (location != null)
            {
                locations.Add(location);
            }
        }

        return locations;
    }

    public LocationOption ParseLine(Row row)
    {
        if (row == null)
        {
            throw new ArgumentException("Row cannot be null", nameof(row));
        }

        if (row.Values.Count != 2)
        {
            throw new ArgumentException("Row is not in the correct format", nameof(row));
        }

        if (!int.TryParse(row.Values[0], out var column1))
        {
            throw new ArgumentException("Column 1 is not an integer", nameof(row));
        }

        if (!int.TryParse(row.Values[1], out var column2))
        {
            throw new ArgumentException("Column 2 is not an integer", nameof(row));
        }

        return new LocationOption
        {
            Column1 = column1,
            Column2 = column2
        };
    }


}
