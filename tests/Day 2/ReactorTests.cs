using Day2.Model;

namespace Day2.Tests
{
    [TestFixture]
    public class ReactorTests
    {

        [Test]
        public void CountSafeReactors_NullReports_ThrowsArgumentNullException()
        {
            var reactor = new Reactor();
            Assert.Throws<ArgumentNullException>(() => reactor.CountSafeReactors(null));
        }

        [Test]
        public void CountSafeReactors_EmptyReports_ReturnsZero()
        {
            var reactor = new Reactor();
            var result = reactor.CountSafeReactors(new List<Report>());
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountSafeReactors_AllSafeReports_ReturnsCorrectCount()
        {
            var reactor = new Reactor();
            var reports = new List<Report>
            {
                new Report { Levels = new List<int> { 1, 2, 3 } },
                new Report { Levels = new List<int> { 3, 2, 1 } }
            };
            var result = reactor.CountSafeReactors(reports);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void CountSafeReactors_MixedReports_ReturnsCorrectCount()
        {
            var reactor = new Reactor();
            var reports = new List<Report>
            {
                new Report { Levels = new List<int> { 1, 2, 3 } },
                new Report { Levels = new List<int> { 3, 2, 1 } },
                new Report { Levels = new List<int> { 1, 1, 1 } }
            };
            var result = reactor.CountSafeReactors(reports);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ReportIsSafe_NullReport_ThrowsArgumentNullException()
        {
            var reactor = new Reactor();
            Assert.Throws<ArgumentNullException>(() => reactor.ReportIsSafe(null));
        }

        [Test]
        public void ReportIsSafe_NullLevels_ThrowsArgumentException()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = null };
            Assert.Throws<ArgumentException>(() => reactor.ReportIsSafe(report));
        }

        [Test]
        public void ReportIsSafe_EmptyLevels_ThrowsArgumentException()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int>() };
            Assert.Throws<ArgumentException>(() => reactor.ReportIsSafe(report));
        }

        [Test]
        public void ReportIsSafe_SafeReport_ReturnsTrue()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 2, 3 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsTrue(result);
        }

        [Test]
        public void ReportIsSafe_UnstableReport_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 2, 1 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }

        [Test]
        public void ReportIsSafe_LargeDifference_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 5 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }



        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine1_ReturnsTrue()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 7, 6, 4, 2, 1 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsTrue(result);
        }

        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine2_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 2, 7, 8, 9 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }

        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine3_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 9, 7, 6, 2, 1 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }

        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine4_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 3, 2, 4, 5 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }

        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine5_ReturnsFalse()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 8, 6, 4, 4, 1 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsFalse(result);
        }

        [Test]
        // sample data from https://adventofcode.com/2024/day/2
        public void ReportIsSafe_SampleDataLine6_ReturnsTrue()
        {
            var reactor = new Reactor();
            var report = new Report { Levels = new List<int> { 1, 3, 6, 7, 9 } };
            var result = reactor.ReportIsSafe(report);
            Assert.IsTrue(result);
        }
    }
}
