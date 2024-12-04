using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Day4;

internal sealed class Parser : IParser
{
    public int Part1(StringCollection wordSearch)
    {
        if (wordSearch == null)
        {
            throw new ArgumentNullException(nameof(wordSearch));
        }


        var total = CaluclateTotalXmasByLine(wordSearch);

        return total;

    }
    internal protected int CaluclateTotalXmasByLine(StringCollection wordSearch)
    {
        int total = 0;
        foreach (var line in wordSearch)
        {
            total += CalculateNumberOfXmas(line);
            total += CalculateNumberOfXmas(Reverse(line));
        }
        return total;
    }

    internal protected int CalculateNumberOfXmas(string line)
    {
        line = line.Replace(".", "");
        var regex = new Regex(@"xmas", RegexOptions.IgnoreCase);
        var matches = regex.Matches(line);
        return matches.Count;
    }

    internal protected string Reverse(string line)
    {
        char[] charArray = line.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
