using FileParse;
using FileParse.Model;
using Moq;
using System.Collections.Specialized;

namespace Day1.Tests
{
    [TestFixture]
    public class ReadLocationsTests
    {
        private Mock<IReadCollectionsFromFile> _mockReadCollectionsFromFile;
        private ReadLocations _readLocations;

        [SetUp]
        public void SetUp()
        {
            _mockReadCollectionsFromFile = new Mock<IReadCollectionsFromFile>();
            _readLocations = new ReadLocations(_mockReadCollectionsFromFile.Object);
        }

        [Test]
        public void ReadLocationsFromFile_FileIsEmpty_ThrowsInvalidOperationException()
        {
            _mockReadCollectionsFromFile.Setup(m => m.ReadFileContentsToCollection(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((List<Row>)null);

            Assert.Throws<InvalidOperationException>(() => _readLocations.ReadLocationsFromFile("test.txt"));
        }

        [Test]
        public void ReadLocationsFromFile_FileHasNoRows_ThrowsInvalidOperationException()
        {
            _mockReadCollectionsFromFile.Setup(m => m.ReadFileContentsToCollection(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<Row>());

            Assert.Throws<InvalidOperationException>(() => _readLocations.ReadLocationsFromFile("test.txt"));
        }

        [Test]
        public void ReadLocationsFromFile_ValidFile_ReturnsLocationOptions()
        {
            var rows = new List<Row>
            {
                new Row { Values = new StringCollection { "1", "2" } },
                new Row { Values = new StringCollection { "3", "4" } }
            };

            _mockReadCollectionsFromFile.Setup(m => m.ReadFileContentsToCollection(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(rows);

            var result = _readLocations.ReadLocationsFromFile("test.txt");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Column1Options.Count());
            Assert.AreEqual(2, result.Column2Options.Count());
        }

        [Test]
        public void ParseLine_RowIsNull_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _readLocations.ParseLine(null));
        }

        [Test]
        public void ParseLine_RowHasIncorrectFormat_ThrowsArgumentException()
        {
            var row = new Row { Values = new StringCollection { "1" } };

            Assert.Throws<ArgumentException>(() => _readLocations.ParseLine(row));
        }

        [Test]
        public void ParseLine_RowHasNonIntegerValues_ThrowsArgumentException()
        {
            var row = new Row { Values = new StringCollection { "a", "b" } };

            Assert.Throws<ArgumentException>(() => _readLocations.ParseLine(row));
        }

        [Test]
        public void ParseLine_ValidRow_ReturnsLocationOption()
        {
            var row = new Row { Values = new StringCollection { "1", "2" } };

            var result = _readLocations.ParseLine(row);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Column1);
            Assert.AreEqual(2, result.Column2);
        }
    }
}
