namespace Day1.Tests
{
    [TestFixture]
    public class ReadLocationsTests
    {

        [Test]
        public void ReadLocationsFromFile_FileNameIsNull_ThrowsArgumentException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<ArgumentException>(() => readLocations.ReadLocationsFromFile(null));
        }

        [Test]
        public void ReadLocationsFromFile_FileNameIsEmpty_ThrowsArgumentException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<ArgumentException>(() => readLocations.ReadLocationsFromFile(string.Empty));
        }

        [Test]
        public void ReadLocationsFromFile_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<FileNotFoundException>(() => readLocations.ReadLocationsFromFile("nonexistentfile.txt"));
        }

        [Test]
        public void ReadLocationsFromFile_FileIsEmpty_ThrowsInvalidOperationException()
        {
            var readLocations = new ReadLocations();
            var fileName = "emptyfile.txt";
            File.WriteAllText(fileName, string.Empty);

            try
            {
                Assert.Throws<InvalidOperationException>(() => readLocations.ReadLocationsFromFile(fileName));
            }
            finally
            {
                File.Delete(fileName);
            }
        }

        [Test]
        public void ReadLocationsFromFile_FileHasValidData_ReturnsLocations()
        {
            var readLocations = new ReadLocations();
            var fileName = "validfile.txt";
            File.WriteAllText(fileName, "1" + Constants.LOCATION_SEPERATION + "2\n3" + Constants.LOCATION_SEPERATION + "4");

            try
            {
                var locations = readLocations.ReadLocationsFromFile(fileName);

                Assert.IsNotNull(locations);
                Assert.AreEqual(2, locations.Column1Options.Count());
                Assert.AreEqual(2, locations.Column2Options.Count());
            }
            finally
            {
                File.Delete(fileName);
            }
        }

        [Test]
        public void ParseLine_LineIsNull_ThrowsArgumentException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<ArgumentException>(() => readLocations.ParseLine(null));
        }

        [Test]
        public void ParseLine_LineIsEmpty_ThrowsArgumentException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<ArgumentException>(() => readLocations.ParseLine(string.Empty));
        }

        [Test]
        public void ParseLine_LineIsNotInCorrectFormat_ThrowsArgumentException()
        {
            var readLocations = new ReadLocations();
            Assert.Throws<ArgumentException>(() => readLocations.ParseLine("1,2"));
        }

        [Test]
        public void ParseLine_LineHasValidData_ReturnsLocation()
        {
            var readLocations = new ReadLocations();
            var location = readLocations.ParseLine("1" + Constants.LOCATION_SEPERATION + "2");

            Assert.AreEqual(1, location.Column1);
            Assert.AreEqual(2, location.Column2);
        }
    }
}
