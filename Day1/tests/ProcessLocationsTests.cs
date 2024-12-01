using Day1.Model;

namespace Day1.Tests
{
    [TestFixture]
    public class ProcessLocationsTests
    {

        [Test]
        public void GetColumn1OptionsOrderd_ShouldReturnOrderedStack()
        {
            var processLocations = new ProcessLocations();
            var locations = new List<LocationOption>
            {
                new LocationOption { Column1 = 3, Column2 = 1 },
                new LocationOption { Column1 = 1, Column2 = 2 },
                new LocationOption { Column1 = 2, Column2 = 3 }
            };

            var result = processLocations.GetColumn1OptionsOrderd(locations);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Pop());
            Assert.AreEqual(2, result.Pop());
            Assert.AreEqual(3, result.Pop());
        }

        [Test]
        public void GetColumn2OptionsOrdered_ShouldReturnOrderedStack()
        {
            var processLocations = new ProcessLocations();
            var locations = new List<LocationOption>
            {
                new LocationOption { Column1 = 3, Column2 = 3 },
                new LocationOption { Column1 = 1, Column2 = 1 },
                new LocationOption { Column1 = 2, Column2 = 2 }
            };

            var result = processLocations.GetColumn2OptionsOrdered(locations);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Pop());
            Assert.AreEqual(2, result.Pop());
            Assert.AreEqual(3, result.Pop());
        }

        [Test]
        public void TotalDistance_ShouldReturnCorrectDistance()
        {
            var processLocations = new ProcessLocations();
            var locations = new List<LocationOption>
            {
                new LocationOption { Column1 = 1, Column2 = 4 },
                new LocationOption { Column1 = 2, Column2 = 5 },
                new LocationOption { Column1 = 3, Column2 = 6 }
            };

            var result = processLocations.TotalDistance(locations);

            Assert.AreEqual(9, result);
        }

        [Test]
        public void TotalDistance_ShouldThrowArgumentNullException_WhenLocationsIsNull()
        {
            var processLocations = new ProcessLocations();
            Assert.Throws<ArgumentNullException>(() => processLocations.TotalDistance(null));
        }

    }
}
