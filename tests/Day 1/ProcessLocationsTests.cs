using Day1.Model;

namespace Day1.Tests;

[TestFixture]
public class ProcessLocationsTests
{


    [Test]
    public void Part1_ShouldReturnCorrectDistance()
    {
        var processLocations = new ProcessLocations();
        var locations = new LocationOptions();
        locations.Add(new LocationOption { Column1 = 1, Column2 = 4 });
        locations.Add(new LocationOption { Column1 = 2, Column2 = 5 });
        locations.Add(new LocationOption { Column1 = 3, Column2 = 6 });

        var result = processLocations.Part1(locations);

        Assert.AreEqual(9, result);
    }

    [Test]
    public void Part1_ShouldThrowArgumentNullException_WhenLocationsIsNull()
    {
        var processLocations = new ProcessLocations();
        Assert.Throws<ArgumentNullException>(() => processLocations.Part1(null));
    }
    [Test]
    public void Part2_LocationsAreNull_ThrowsArgumentNullException()
    {
        var processLocations = new ProcessLocations();
        Assert.Throws<ArgumentNullException>(() => processLocations.Part2(null));
    }


    [Test]
    public void Part2_ValidLocations_ReturnsCorrectScore()
    {
        var processLocations = new ProcessLocations();
        var locations = new LocationOptions();
        locations.Add(new LocationOption { Column1 = 1, Column2 = 1 });
        locations.Add(new LocationOption { Column1 = 2, Column2 = 2 });
        locations.Add(new LocationOption { Column1 = 3, Column2 = 3 });

        var result = processLocations.Part2(locations);

        Assert.AreEqual(6, result);
    }

    [Test]
    public void Part2_DuplicateValuesInColumn1_ReturnsCorrectScore()
    {
        var locations = new LocationOptions();
        var processLocations = new ProcessLocations();
        locations.Add(new LocationOption { Column1 = 1, Column2 = 1 });
        locations.Add(new LocationOption { Column1 = 1, Column2 = 2 });
        locations.Add(new LocationOption { Column1 = 2, Column2 = 2 });

        var result = processLocations.Part2(locations);

        Assert.AreEqual(6, result);
    }
}
