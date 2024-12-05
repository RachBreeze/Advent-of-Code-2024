using Day5.Model;

namespace Day5.Tests;

[TestFixture]
public class PageOrderPairsTests
{
    [Test]
    public void Equals_SamePageNumbers_ReturnsTrue()
    {
        var pair1 = new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 };
        var pair2 = new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 };

        Assert.IsTrue(pair1.Equals(pair2));
    }

    [Test]
    public void Equals_DifferentPageNumbers_ReturnsFalse()
    {
        var pair1 = new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 };
        var pair2 = new PageOrderPairs { PageNumber1 = 2, PageNumber2 = 3 };

        Assert.IsFalse(pair1.Equals(pair2));
    }

    [Test]
    public void Equals_NullObject_ReturnsFalse()
    {
        var pair1 = new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 };

        Assert.IsFalse(pair1.Equals(null));
    }

    [Test]
    public void Equals_DifferentType_ReturnsFalse()
    {
        var pair1 = new PageOrderPairs { PageNumber1 = 1, PageNumber2 = 2 };
        var differentTypeObject = new object();

        Assert.IsFalse(pair1.Equals(differentTypeObject));
    }
}
