using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace FunctionalTest
{
    public class TestServerBuilder
    {
        public TestServer Build()
        {
            var application = new WebApplicationFactory<Program>();

            return application.Server;
        }
    }
}
