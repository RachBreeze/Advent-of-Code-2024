using Day2.Model;

namespace Day2;

internal class Reactor : IReactor
{
    public int CountSafeReactors(IEnumerable<Report> reports)
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
            if (ReportIsSafe(report))
            {
                count++;
            }
        }

        return count;
    }
    public bool ReportIsSafe(Report report)
    {
        if (report == null)
        {
            throw new ArgumentNullException(nameof(report));
        }
        if (report.Levels == null)
        {
            throw new ArgumentException("Report levels cannot be null", nameof(report));
        }
        if (report.Levels.Count == 0)
        {
            throw new ArgumentException("Report levels cannot be empty", nameof(report));
        }

        int currentValue = report.Levels[0];
        var increasing = false;
        var descreasing = false;

        for (int i = 1; i < report.Levels.Count; i++)
        {
            int nextValue = report.Levels[i];

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
