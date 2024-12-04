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
        total += CalculateTotalXmasByColumn(grid);
        total += CalculateTotalXmasByLeftToRightDiagonal(grid);
        return total;

    }

    internal protected int CalculateTotalXmasByLeftToRightDiagonal(Dictionary<int, char[]> grid)
    {
        var rows = ConvertLeftoRightDiagonalToRows(grid);
        return CalculateTotalXmasByLine(rows);
    }

    internal protected StringCollection ConvertLeftoRightDiagonalToRows(Dictionary<int, char[]> grid)
    {
        if (grid == null)
        {
            throw new ArgumentNullException(nameof(grid));
        }
        if (grid.Count == 0)
        {
            return new StringCollection();
        }
        var firstPass = true;
        var totalRows = grid.Count;
        var totalColumns = grid[0].Length;
        var rows = new StringCollection();

        for (int row = 0; row < totalRows; row++)
        {

            for (int column = 0; column < totalColumns; column++)
            {
                var line = GetDiagonal(grid, row, column);
                if (line.Length >= 4)
                {
                    rows.Add(line);
                }
                if (!firstPass)
                {
                    break;
                }
            }
            firstPass = false;
        }
        return rows;
    }

    internal protected string GetDiagonal(Dictionary<int, char[]> grid, int row, int column)
    {
        var line = string.Empty;
        if (row >= grid.Count || column >= grid[0].Length)
        {
            return line;
        }

        return grid[row][column].ToString() + GetDiagonal(grid, row + 1, column + 1);
    }

    internal protected int CalculateTotalXmasByColumn(Dictionary<int, char[]> grid)
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
