using Day2.Model;

namespace Day2
{
    internal interface IReactor
    {
        int CountSafeReactors(IEnumerable<Report> reports);
    }
}