namespace FileParse.Tests
{
    [TestFixture]
    public class ReadCollectionsFromFileTests
    {

        [Test]
        public void ReadFileContentsToCollection_FileNameIsNull_ThrowsArgumentException()
        {
            var reader = new ReadCollectionsFromFile();
            Assert.Throws<ArgumentException>(() => reader.ReadFileContentsToCollection(null, ","));
        }

        [Test]
        public void ReadFileContentsToCollection_FileNameIsEmpty_ThrowsArgumentException()
        {
            var reader = new ReadCollectionsFromFile();
            Assert.Throws<ArgumentException>(() => reader.ReadFileContentsToCollection(string.Empty, ","));
        }

        [Test]
        public void ReadFileContentsToCollection_FileDoesNotExist_ThrowsFileNotFoundException()
        {
            var reader = new ReadCollectionsFromFile();
            Assert.Throws<FileNotFoundException>(() => reader.ReadFileContentsToCollection("nonexistentfile.txt", ","));
        }

        [Test]
        public void ReadFileContentsToCollection_FileIsEmpty_ThrowsInvalidOperationException()
        {
            var reader = new ReadCollectionsFromFile();
            var fileName = "emptyfile.txt";
            File.WriteAllText(fileName, string.Empty);

            try
            {
                Assert.Throws<InvalidOperationException>(() => reader.ReadFileContentsToCollection(fileName, ","));
            }
            finally
            {
                File.Delete(fileName);
            }
        }

        [Test]
        public void ReadFileContentsToCollection_ValidFile_ReturnsCorrectRows()
        {
            var reader = new ReadCollectionsFromFile();
            var fileName = "validfile.txt";
            var content = "value1,value2\nvalue3,value4";
            File.WriteAllText(fileName, content);

            try
            {
                var result = reader.ReadFileContentsToCollection(fileName, ",");

                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(0, result[0].Index);
                Assert.AreEqual(1, result[1].Index);
                CollectionAssert.AreEqual(new[] { "value1", "value2" }, result[0].Values);
                CollectionAssert.AreEqual(new[] { "value3", "value4" }, result[1].Values);
            }
            finally
            {
                File.Delete(fileName);
            }
        }

    }
}
