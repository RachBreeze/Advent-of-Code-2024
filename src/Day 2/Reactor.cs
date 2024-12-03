using Day2.Model;

namespace Day2;

internal class Reactor : IReactor
{
    public int Part1(IEnumerable<Report> reports)
    {
        if (reports == null)
        {
            throw new ArgumentNullException(nameof(reports));
        }

        if (!reports.Any())
        {
            return 0;
        }

        var count = 0;

        foreach (var report in reports)
        {
            if (ReportIsSafe(report.Levels))
            {
                count++;
            }
        }

        return count;
    }
    public int Part2(IEnumerable<Report> reports)
    {
        if (reports == null)
        {
            throw new ArgumentNullException(nameof(reports));
        }

        if (!reports.Any())
        {
            return 0;
        }

        var count = 0;

        foreach (var report in reports)
        {
            if (ReportIsSafeUsingDampner(report.Levels))
            {
                count++;
            }
        }
        return count;
    }

    internal protected bool ReportIsSafeUsingDampner(List<int> levels)
    {
        int itemToRemove = -1;

        if (ReportIsSafe(levels))
        {
            return true;
        }

        while (itemToRemove < levels.Count - 1)
        {
            itemToRemove++;
            var newLevels = new List<int>(levels);
            newLevels.RemoveAt(itemToRemove);
            if (ReportIsSafe(newLevels))
            {
                return true;
            }
        }
        return false;
    }
    internal protected bool ReportIsSafe(List<int> levels)
    {
        if (levels == null)
        {
            throw new ArgumentNullException(nameof(levels));
        }

        if (levels.Count == 0)
        {
            throw new ArgumentException("Report levels cannot be empty", nameof(levels));
        }

        int currentValue = levels[0];
        var increasing = false;
        var descreasing = false;

        for (int i = 1; i < levels.Count; i++)
        {
            int nextValue = levels[i];

            if (nextValue == currentValue)
            {
                return false;
            }
            else if (nextValue > currentValue)
            {
                increasing = true;
            }
            else
            {
                descreasing = true;
            }
            if (increasing && descreasing)
            {
                return false;
            }

            var diff = Math.Abs(nextValue - currentValue);

            if (diff > 3)
            {
                return false;
            }
            currentValue = nextValue;
        }

        return true;
    }


}
