using System.Reflection;
using Xunit.Sdk;

namespace FunctionalTest.Fixtures.Resets
{
    public class ResetProductsService : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            TestHostFixture.ResetProductsService();
        }
    }
}
