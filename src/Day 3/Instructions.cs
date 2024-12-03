using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Day3;

internal class Instructions : IInstructions
{
    public int TotalMultiplications(StringCollection memory)
    {
        if (memory == null)
        {
            throw new ArgumentNullException(nameof(memory));
        }

        if (memory.Count == 0)
        {
            throw new ArgumentException("Memory is empty", nameof(memory));
        }


        var total = 0;

        foreach (var line in memory)
        {
            total += LineTotal(line);
        }
        return total;
    }
    public int LineTotal(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            throw new ArgumentException("Line cannot be null or empty", nameof(line));
        }
        List<string> patterns = Regex.Matches(line, @"mul\(\d+,\d+\)").Select(match => match.Value).ToList();
        int total = 0;

        foreach (var pattern in patterns)
        {
            total += PatternTotal(pattern);
        }

        return total;
    }

    public int PatternTotal(string availabileInstruction)
    {
        if (string.IsNullOrEmpty(availabileInstruction))
        {
            return 0;
        }

        var availableValues = availabileInstruction.Replace("mul(", "").Replace(")", "");

        var values = availableValues.Split(",");

        if (!int.TryParse(values[0], out var value1))
        {
            return 0;
        }

        if (!int.TryParse(values[1], out var value2))
        {
            return 0;
        }

        return value1 * value2;
    }
}
