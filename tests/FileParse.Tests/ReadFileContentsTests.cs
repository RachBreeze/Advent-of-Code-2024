using System.Collections.Specialized;

namespace FileParse.Tests;

[TestFixture]
public class ReadFileContentsTests
{

    [Test]
    public void ReadFileContentsToCollection_FileNameIsNull_ThrowsArgumentException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<ArgumentException>(() => reader.AsCollections(null, ","));
    }

    [Test]
    public void ReadFileContentsToCollection_FileNameIsEmpty_ThrowsArgumentException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<ArgumentException>(() => reader.AsCollections(string.Empty, ","));
    }

    [Test]
    public void ReadFileContentsToCollection_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<FileNotFoundException>(() => reader.AsCollections("nonexistentfile.txt", ","));
    }

    [Test]
    public void ReadFileContentsToCollection_FileIsEmpty_ThrowsInvalidOperationException()
    {
        var reader = new ReadFileContents();
        var fileName = "emptyfile.txt";
        File.WriteAllText(fileName, string.Empty);

        try
        {
            Assert.Throws<InvalidOperationException>(() => reader.AsCollections(fileName, ","));
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [Test]
    public void ReadFileContentsToCollection_ValidFile_ReturnsCorrectRows()
    {
        var reader = new ReadFileContents();
        var fileName = "validfile.txt";
        var content = "value1,value2\nvalue3,value4";
        File.WriteAllText(fileName, content);

        try
        {
            var result = reader.AsCollections(fileName, ",");

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

    [Test]
    public void AsLines_FileNameIsNull_ThrowsArgumentException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<ArgumentException>(() => reader.AsLines(null));
    }

    [Test]
    public void AsLines_FileNameIsEmpty_ThrowsArgumentException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<ArgumentException>(() => reader.AsLines(string.Empty));
    }

    [Test]
    public void AsLines_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        var reader = new ReadFileContents();
        Assert.Throws<FileNotFoundException>(() => reader.AsLines("nonexistentfile.txt"));
    }

    [Test]
    public void AsLines_FileIsEmpty_ThrowsInvalidOperationException()
    {
        var reader = new ReadFileContents();
        var fileName = "emptyfile.txt";
        File.WriteAllText(fileName, string.Empty);

        try
        {
            Assert.Throws<InvalidOperationException>(() => reader.AsLines(fileName));
        }
        finally
        {
            File.Delete(fileName);
        }
    }

    [Test]
    public void AsLines_ValidFile_ReturnsStringCollection()
    {
        var reader = new ReadFileContents();
        var fileName = "validfile.txt";
        var fileContent = "line1\nline2\nline3";
        File.WriteAllText(fileName, fileContent);

        try
        {
            var result = reader.AsLines(fileName);

            Assert.IsInstanceOf<StringCollection>(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("line1", result[0]);
            Assert.AreEqual("line2", result[1]);
            Assert.AreEqual("line3", result[2]);
        }
        finally
        {
            File.Delete(fileName);
        }
    }
}

