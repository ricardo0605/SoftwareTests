using Xunit;

namespace Feature.Tests._03___Ordination
{
    /// <summary>
    /// https://github.com/asherber/Xunit.Priority
    /// </summary>
    [TestCaseOrderer("Feature.Tests._03___Ordination.PriorityOrderer", "Feature.Tests")]
    public class OrdinationTests
    {
        public static bool TestOneCalled { get; set; }
        public static bool TestTwoCalled { get; set; }
        public static bool TestThreeCalled { get; set; }


        [Fact(DisplayName = "Test One"), TestPriority(1)]
        [Trait("Category", "Ordination")]
        public void TestOne()
        {
            TestOneCalled = true;

            Assert.False(TestTwoCalled);
            Assert.False(TestThreeCalled);
        }

        [Fact(DisplayName = "Test Two"), TestPriority(2)]
        [Trait("Category", "Ordination")]
        public void TestTwo()
        {
            TestTwoCalled = true;

            Assert.True(TestOneCalled);
            Assert.False(TestThreeCalled);

        }

        [Fact(DisplayName = "Test Three"), TestPriority(3)]
        [Trait("Category", "Ordination")]
        public void TestThree()
        {
            TestThreeCalled = true;

            Assert.True(TestOneCalled);
            Assert.True(TestTwoCalled);
        }
    }
}
