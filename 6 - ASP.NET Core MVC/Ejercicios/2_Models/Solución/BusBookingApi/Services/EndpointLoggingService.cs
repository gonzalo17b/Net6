namespace BusBookingApi.Services
{
    public class EndpointLoggingService
    {
        private readonly Dictionary<string, int> _myDictionary;

        public EndpointLoggingService()
        {
            _myDictionary = new Dictionary<string, int>();
        }

        public void AddRequest(string path)
        {
            if (_myDictionary.ContainsKey(path))
            {
                _myDictionary[path] = _myDictionary[path] + 1;
            }
            else
            {
                _myDictionary.Add(path, 1);
            }
        }

        public IReadOnlyDictionary<string, int> GetElements()
        {
            return _myDictionary;
        }
    }
}
