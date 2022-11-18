namespace BusBookingApi.Services
{
    public class EndpointLoginService
    {
        private Dictionary<string, int> _endpoints;
        public EndpointLoginService()
        {
            _endpoints = new Dictionary<string, int>();
        }

        public void AddRequest(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            var exists = _endpoints.ContainsKey(path);
            if (exists)
            {
                _endpoints[path] = _endpoints[path] + 1;
            }
            else
            {
                _endpoints.Add(path, 1);
            }
        }

        public IReadOnlyDictionary<string, int> GetElements()
        {
            return _endpoints;
        }
    }
}
