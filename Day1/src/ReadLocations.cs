using Day1.Model;

namespace Day1;

internal class ReadLocations : IReadLocations
{
    public LocationOptions ReadLocationsFromFile(string fileName)
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

        var locations = new LocationOptions();
        foreach (var line in lines)
        {
            var location = ParseLine(line);
            if (location != null)
            {
                locations.Add(location);
            }
        }

        return locations;
    }

    public LocationOption ParseLine(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            throw new ArgumentException("Location cannot be null or empty", nameof(line));
        }
        if (!line.Contains(Constants.LOCATION_SEPERATION))
        {
            throw new ArgumentException("Location is not in the correct format", nameof(line));
        }
        var entries = line.Split(Constants.LOCATION_SEPERATION);

        if (entries.Count() != 2)
        {
            throw new ArgumentException("Location is not in the correct format", nameof(line));
        }

        return new LocationOption
        {
            Column1 = int.Parse(entries[0]),
            Column2 = int.Parse(entries[1])
        };
    }


}
