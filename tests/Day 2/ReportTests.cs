using Day2.Model;

namespace Day2.Tests;

[TestFixture]
public class ReportTests
{
    [Test]
    public void Report_Constructor_InitializesLevels()
    {
        // Arrange & Act
        var report = new Report();

        // Assert
        Assert.IsNotNull(report.Levels);
        Assert.IsInstanceOf<List<int>>(report.Levels);
    }

    [Test]
    public void Report_Levels_SetAndGet()
    {
        // Arrange
        var report = new Report();
        var levels = new List<int> { 1, 2, 3 };

        // Act
        report.Levels = levels;

        // Assert
        Assert.AreEqual(levels, report.Levels);
    }
}
