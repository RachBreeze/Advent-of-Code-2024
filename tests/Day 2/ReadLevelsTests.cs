using FileParse;
using FileParse.Model;
using Moq;
using System.Collections.Specialized;

namespace Day2.Tests;

[TestFixture]
public class ReadLevelsTests
{
    private Mock<IReadFileContents> _mockReadCollectionsFromFile;
    private ReadLevels _readLevels;

    [SetUp]
    public void SetUp()
    {
        _mockReadCollectionsFromFile = new Mock<IReadFileContents>();
        _readLevels = new ReadLevels(_mockReadCollectionsFromFile.Object);
    }

    [Test]
    public void ReadReportsFromFile_FileIsEmpty_ThrowsInvalidOperationException()
    {
        _mockReadCollectionsFromFile.Setup(x => x.AsCollections(It.IsAny<string>(), It.IsAny<string>()))
            .Returns((List<Row>)null);

        Assert.Throws<InvalidOperationException>(() => _readLevels.ReadReportsFromFile("testfile.txt"));
    }

    [Test]
    public void ReadReportsFromFile_FileHasNoRows_ThrowsInvalidOperationException()
    {
        _mockReadCollectionsFromFile.Setup(x => x.AsCollections(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(new List<Row>());

        Assert.Throws<InvalidOperationException>(() => _readLevels.ReadReportsFromFile("testfile.txt"));
    }

    [Test]
    public void ReadReportsFromFile_ValidFile_ReturnsReports()
    {
        var rows = new List<Row>
        {
            new Row { Values = new StringCollection { "1", "2", "3" } },
            new Row { Values = new StringCollection { "4", "5", "6" } }
        };

        _mockReadCollectionsFromFile.Setup(x => x.AsCollections(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(rows);

        var reports = _readLevels.ReadReportsFromFile("testfile.txt");

        Assert.AreEqual(2, reports.Count());
        Assert.AreEqual(new List<int> { 1, 2, 3 }, reports.ToList()[0].Levels);
        Assert.AreEqual(new List<int> { 4, 5, 6 }, reports.ToList()[1].Levels);
    }


}
