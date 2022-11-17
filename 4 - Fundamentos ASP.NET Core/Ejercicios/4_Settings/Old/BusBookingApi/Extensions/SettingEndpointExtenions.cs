using BusBookingApi.Settings;

namespace BusBookingApi.Extensions
{
    public static class SettingEndpointExtenions
    {
        public static WebApplication MapSettingEndpoints(this WebApplication app)
        {
            app.MapGet("/settings", (IConfiguration configuration) =>
            {
                var settingSection = configuration
                                        .GetSection(nameof(ProjectSettings))
                                        .Get<ProjectSettings>();

                return settingSection;
                
                //return new ProjectSettings
                //{
                //    Environment = settingSection.GetValue<string>(nameof(ProjectSettings.Environment)),
                //    Name = settingSection.GetValue<string>(nameof(ProjectSettings.Name)),
                //    Version = settingSection.GetValue<string>(nameof(ProjectSettings.Version))
                //};
            });
            return app;
        }
    }
}
