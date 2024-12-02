using Day1.Model;
namespace Day1.Tests;
[TestFixture]
public class LocationOptionsTests
{
    [Test]
    public void Column1Options_ShouldReturnAllColumn1Values()
    {
        // Arrange
        var locationOptions = new LocationOptions();
        var location1 = new LocationOption { Column1 = 1, Column2 = 2 };
        var location2 = new LocationOption { Column1 = 3, Column2 = 4 };
        locationOptions.Add(location1);
        locationOptions.Add(location2);

        // Act
        var column1Options = locationOptions.Column1Options.ToList();

        // Assert
        Assert.AreEqual(2, column1Options.Count);
        Assert.Contains(1, column1Options);
        Assert.Contains(3, column1Options);
    }

    [Test]
    public void Column2Options_ShouldReturnAllColumn2Values()
    {
        // Arrange
        var locationOptions = new LocationOptions();
        var location1 = new LocationOption { Column1 = 1, Column2 = 2 };
        var location2 = new LocationOption { Column1 = 3, Column2 = 4 };
        locationOptions.Add(location1);
        locationOptions.Add(location2);

        // Act
        var column2Options = locationOptions.Column2Options.ToList();

        // Assert
        Assert.AreEqual(2, column2Options.Count);
        Assert.Contains(2, column2Options);
        Assert.Contains(4, column2Options);
    }
}
