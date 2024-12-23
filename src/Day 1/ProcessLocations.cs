﻿using Day1.Model;

namespace Day1;
internal sealed class ProcessLocations : IProcessLocations
{

    private Stack<int> GetColumn1OptionsOrderd(LocationOptions locations)
    {
        return GetStack(locations.Column1Options);
    }

    private Stack<int> GetStack(IEnumerable<int> cols)
    {
        return new Stack<int>(cols.OrderDescending());
    }

    private Stack<int> GetColumn2OptionsOrdered(LocationOptions locations)
    {
        return GetStack(locations.Column2Options);
    }
    public int Part1(LocationOptions locations)
    {
        if (locations == null)
        {
            throw new ArgumentNullException(nameof(locations));
        }

        var locations1 = GetColumn1OptionsOrderd(locations);
        var locations2 = GetColumn2OptionsOrdered(locations);

        if (locations1.Count != locations2.Count)
        {
            throw new InvalidOperationException("Locations are not the same length");
        }

        var distance = 0;

        while (locations1.Count > 0)
        {
            distance += Math.Abs(locations1.Pop() - locations2.Pop());
        }

        return distance;
    }

    public int Part2(LocationOptions locations)
    {
        if (locations == null)
        {
            throw new ArgumentNullException(nameof(locations));
        }
        var locations1 = locations.Column1Options;
        var locations2 = locations.Column2Options;

        if (locations1.Count() != locations2.Count())
        {
            throw new InvalidOperationException("Locations are not the same length");
        }

        var similarityScore = 0;
        var scoreCache = new Dictionary<int, int>();

        foreach (var location in locations1)
        {
            if (scoreCache.ContainsKey(location))
            {
                similarityScore += scoreCache[location];
            }
            else
            {
                var count = locations2.Count(l => l == location);
                var score = count * location;
                similarityScore += score;
                scoreCache.Add(location, score);
            }
        }

        return similarityScore;
    }
}
