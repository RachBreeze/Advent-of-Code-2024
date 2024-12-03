using Day2.Model;

namespace Day2
{
    internal interface IReactor
    {
        int Part1(IEnumerable<Report> reports);

        int Part2(IEnumerable<Report> reports);
    }
}