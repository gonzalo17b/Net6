namespace BusBookingApi.Settings
{
    public class ProjectSettings
    {
        public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Environment { get; set; } = string.Empty;
        public string ExternalApiKey { get; set; } = string.Empty;

        public bool ExternalApiKeyEnabled => !string.IsNullOrEmpty(ExternalApiKey);

        public string Message { get; set; } = string.Empty;

    }
}
