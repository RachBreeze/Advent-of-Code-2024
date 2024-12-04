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

        var grid = ConvertoGrid(wordSearch);

        var total = CalculateTotalXmasByLine(wordSearch);
        total += CalculateTotaleXmasByColumn(grid);
        return total;

    }

    internal protected int CalculateTotaleXmasByColumn(Dictionary<int, char[]> grid)
    {
        var rows = ConvertColumnsToRows(grid);
        return CalculateTotalXmasByLine(rows);
    }

    internal protected StringCollection ConvertColumnsToRows(Dictionary<int, char[]> grid)
    {
        if (grid == null)
        {
            throw new ArgumentNullException(nameof(grid));
        }
        if (grid.Count == 0)
        {
            return new StringCollection();
        }
        var totalColumns = grid[0].Length;
        var rows = new StringCollection();

        for (int i = 0; i < totalColumns; i++)
        {
            var row = string.Empty;
            foreach (var column in grid)
            {
                row += column.Value[i];
            }
            rows.Add(row);
        }

        return rows;
    }

    internal protected Dictionary<int, char[]> ConvertoGrid(StringCollection wordSearch)
    {
        if (wordSearch == null)
        {
            throw new ArgumentNullException(nameof(wordSearch));
        }

        var grid = new Dictionary<int, char[]>();
        for (int i = 0; i < wordSearch.Count; i++)
        {
            grid.Add(i, wordSearch[i].ToCharArray());
        }
        return grid;
    }
    internal protected int CalculateTotalXmasByLine(StringCollection wordSearch)
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
