using FunctionalTest.Fixtures;
using Xunit;

namespace FunctionalTest.Collections
{
    [CollectionDefinition(TestConstants.TestCollection)]
    public class OrderAppCollection : ICollectionFixture<TestHostFixture>
    {
    }
}
