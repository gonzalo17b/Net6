using System.Reflection;
using Xunit.Sdk;

namespace FunctionalTest.Fixtures.Resets
{
    public class ResetCustomersService : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            TestHostFixture.ResetCustomersService();
        }
    }
}
