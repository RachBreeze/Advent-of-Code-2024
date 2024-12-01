namespace Day1.Model
{
    public class LocationOptions
    {
        private readonly List<LocationOption> _locations;
        public LocationOptions()
        {
            _locations = new List<LocationOption>();
        }
        public void Add(LocationOption location)
        {
            _locations.Add(location);
        }

        public IEnumerable<int> Column1Options => _locations.Select(l => l.Column1);
        public IEnumerable<int> Column2Options => _locations.Select(l => l.Column2);
    }
}
