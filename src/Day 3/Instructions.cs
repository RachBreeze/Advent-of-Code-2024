using System.Text.RegularExpressions;

namespace Day3;

internal class Instructions : IInstructions
{
    public int TotalMultiplications(string memory)
    {
        if (string.IsNullOrEmpty(memory))
        {
            throw new ArgumentNullException(nameof(memory));
        }
        List<string> patterns = Regex.Matches(memory, @"mul\(\d+,\d+\)").Select(match => match.Value).ToList();
        int total = 0;

        foreach (var pattern in patterns)
        {
            total += PatternTotal(pattern);
        }

        return total;

    }

    public int TotalWithConditionalStatements(string memory)
    {
        if (memory == null)
        {
            throw new ArgumentNullException(nameof(memory));
        }


        var validEntries = GetValidEntries(memory);
        return TotalMultiplications(validEntries);

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
    public string GetValidEntries(string line)
    {
        var doos = line.Split("do()");
        var returnString = "";

        foreach (var doo in doos)
        {
            var donts = doo.Split("don't()");
            returnString += donts[0];
        }

        return returnString;
    }
}
