using Day5.Model;
namespace Day5.Tests;
[TestFixture]
public class ManualTests
{
    [Test]
    public void AddPage_ShouldAddPageToList()
    {
        // Arrange
        var manual = new Manual();
        int page = 1;

        // Act
        manual.AddPage(page);

        // Assert
        Assert.Contains(page, manual.Pages.ToList());
    }

    [Test]
    public void Pages_ShouldReturnAllAddedPages()
    {
        // Arrange
        var manual = new Manual();
        int[] pages = { 1, 2, 3 };

        // Act
        foreach (var page in pages)
        {
            manual.AddPage(page);
        }

        // Assert
        CollectionAssert.AreEqual(pages, manual.Pages);
    }
}