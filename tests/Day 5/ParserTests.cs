using Day5.Model;
using System.Collections.Specialized;

namespace Day5.Tests;

[TestFixture]
public class ParserTests
{

    [Test]
    public void ReadPageOrdering_InputIsNull_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.ReadPageOrdering(null));
    }

    [Test]
    public void ReadPageOrdering_InputIsEmpty_ReturnsEmptyList()
    {
        var parser = new Parser();
        var input = new StringCollection();
        var result = parser.ReadPageOrdering(input);
        Assert.IsEmpty(result);
    }

    [Test]
    public void ReadPageOrdering_ValidInput_ReturnsCorrectPageOrderPairs()
    {
        var parser = new Parser();
        var input = new StringCollection { "1|2", "3|4" };
        var result = parser.ReadPageOrdering(input);

        IEnumerable<PageOrderPairs> expected = new List<PageOrderPairs>
        {
            new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 },
            new PageOrderPairs { PageNumber1 = 3, PageNumber2 = 4 }
        };
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void ReadPageOrdering_InvalidPageOrder_ThrowsException()
    {
        var parser = new Parser();
        var input = new StringCollection { "1|2", "invalid|4" };
        Assert.Throws<ArgumentException>(() => parser.ReadPageOrdering(input));
    }

    [Test]
    public void ReadPageOrdering_InvalidPageNumber_ThrowsException()
    {
        var parser = new Parser();
        var input = new StringCollection { "1|2", "3|invalid" };
        Assert.Throws<ArgumentException>(() => parser.ReadPageOrdering(input));
    }

    [Test]
    public void ReadManuals_ValidInput_ReturnsManual()
    {
        // Arrange
        var parser = new Parser();
        string input = "1,2,3";

        // Act
        var result = parser.ReadManual(input);

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.Pages);
    }

    [Test]
    public void ReadManuals_EmptyInput_ReturnsNull()
    {
        // Arrange
        var parser = new Parser();
        string input = "";

        // Act
        var result = parser.ReadManual(input);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void ReadManuals_InputWithoutComma_ReturnsNull()
    {
        // Arrange
        var parser = new Parser();
        string input = "123";

        // Act
        var result = parser.ReadManual(input);

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void ReadManuals_InvalidPageNumber_ThrowsArgumentException()
    {
        // Arrange
        var parser = new Parser();
        string input = "1,2,abc";

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => parser.ReadManual(input));
        Assert.That(ex.Message, Is.EqualTo("Invalid page number abc for 1,2,abc"));
    }
    [Test]
    public void ReadManuals_ValidInput_ReturnsManuals()
    {
        // Arrange
        var parser = new Parser();
        var input = new StringCollection { "1,2,3", "4,5,6" };

        // Act
        var result = parser.ReadManuals(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
        CollectionAssert.AreEqual(new[] { 1, 2, 3 }, result.ElementAt(0).Pages);
        CollectionAssert.AreEqual(new[] { 4, 5, 6 }, result.ElementAt(1).Pages);
    }

    [Test]
    public void ReadManuals_EmptyInput_ReturnsEmptyList()
    {
        // Arrange
        var parser = new Parser();
        var input = new StringCollection();

        // Act
        var result = parser.ReadManuals(input);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void ReadManuals_InputWithInvalidPageNumber_ThrowsArgumentException()
    {
        // Arrange
        var parser = new Parser();
        var input = new StringCollection { "1,2,abc" };

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => parser.ReadManuals(input));
        Assert.That(ex.Message, Is.EqualTo("Invalid page number abc for 1,2,abc"));
    }

    [Test]
    public void ReadManuals_NullInput_ThrowsArgumentNullException()
    {
        // Act & Assert
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.ReadManuals(null));
    }

    [Test]
    public void IsValidManual_ValidManual_ReturnsTrue()
    {
        var parser = new Parser();
        var manual = new Manual();
        manual.AddPage(1);
        manual.AddPage(2);
        manual.AddPage(3);

        var pageOrdering = new List<PageOrderPairs>
            {
                new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 },
                new PageOrderPairs { PageNumber1 = 2, PageNumber2 = 3 }
            };

        var result = parser.IsValidManual(manual, pageOrdering);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsValidManual_InvalidManual_ReturnsFalse()
    {
        var parser = new Parser();
        var manual = new Manual();
        manual.AddPage(1);
        manual.AddPage(3);
        manual.AddPage(2);

        var pageOrdering = new List<PageOrderPairs>
            {
                new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 },
                new PageOrderPairs { PageNumber1 = 2, PageNumber2 = 3 }
            };

        var result = parser.IsValidManual(manual, pageOrdering);

        Assert.IsFalse(result);
    }

    [Test]
    public void IsValidManual_EmptyManual_ReturnsTrue()
    {
        var parser = new Parser();
        var manual = new Manual();
        var pageOrdering = new List<PageOrderPairs>();

        var result = parser.IsValidManual(manual, pageOrdering);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsValidManual_NullManual_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.IsValidManual(null, new List<PageOrderPairs>()));
    }

    [Test]
    public void IsValidManual_NullPageOrdering_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        var manual = new Manual();
        Assert.Throws<ArgumentNullException>(() => parser.IsValidManual(manual, null));
    }

    [Test]
    public void GetMiddlePage_WithNullManual_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new Parser();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.GetMiddlePage(null));
    }

    [Test]
    public void GetMiddlePage_WithEmptyPages_ReturnsZero()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual();

        // Act
        var result = parser.GetMiddlePage(manual);

        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void GetMiddlePage_WithSinglePage_ReturnsThatPage()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual();
        manual.AddPage(5);

        // Act
        var result = parser.GetMiddlePage(manual);

        // Assert
        Assert.AreEqual(5, result);
    }

    [Test]
    public void GetMiddlePage_WithMultiplePages_ReturnsMiddlePage()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual();
        manual.AddPage(1);
        manual.AddPage(2);
        manual.AddPage(3);

        // Act
        var result = parser.GetMiddlePage(manual);

        // Assert
        Assert.AreEqual(2, result);
    }
    [Test]
    public void OrderManualCorrectly_ValidManual_ReturnsOrderedManual()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual(new List<int> { 3, 1, 2 });
        var pageOrdering = new List<PageOrderPairs>
            {
                new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 },
                new PageOrderPairs { PageNumber1 = 2, PageNumber2 = 3 }
            };

        // Act
        var result = parser.OrderManualCorrectly(manual, pageOrdering) as Manual;

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result.Pages.ToList());
    }

    [Test]
    public void OrderManualCorrectly_InvalidManual_ReturnsOrderedManual()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual(new List<int> { 3, 2, 1 });
        var pageOrdering = new List<PageOrderPairs>
            {
                new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 },
                new PageOrderPairs { PageNumber1 = 2, PageNumber2 = 3 }
            };

        // Act
        var result = parser.OrderManualCorrectly(manual, pageOrdering) as Manual;

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result.Pages.ToList());
    }

    [Test]
    public void OrderManualCorrectly_EmptyManual_ReturnsEmptyManual()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual(new List<int>());
        var pageOrdering = new List<PageOrderPairs>();

        // Act
        var result = parser.OrderManualCorrectly(manual, pageOrdering) as Manual;

        // Assert
        Assert.IsNotNull(result);
        CollectionAssert.AreEqual(new List<int>(), result.Pages.ToList());
    }

    [Test]
    public void OrderManualCorrectly_NullManual_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new Parser();
        Manual manual = null;
        var pageOrdering = new List<PageOrderPairs>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.OrderManualCorrectly(manual, pageOrdering));
    }

    [Test]
    public void OrderManualCorrectly_NullPageOrdering_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new Parser();
        var manual = new Manual(new List<int> { 1, 2, 3 });
        IEnumerable<PageOrderPairs> pageOrdering = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.OrderManualCorrectly(manual, pageOrdering));
    }
}
