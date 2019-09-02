using NUnit.Framework;
using TokenizerNet.Core.Domain;

namespace TokenizerNet.Tests
{
    [TestFixture]
    [Category("Span tests")]
    public sealed class SpanTests
    {
        [Test]
        public void ContainsTest()
        {
            // Arrange
            var first = new CodeSpan(41, 90);
            var second = new CodeSpan(84);
            var third = new CodeSpan(1488, 1498);
            var fourth = new CodeSpan(64285);

            // Act
            var result_1 = first.Contains(second);
            var result_2 = third.Contains(second);
            var result_3 = fourth.Contains(second);

            // Assert
            Assert.IsTrue(result_1, "84 is inside 41 and 90 failed");
            Assert.IsFalse(result_2, "84 is not inside 1488 and 1498 failed");
            Assert.IsFalse(result_3, "84 is not inside 64285 failed");
        }
    }
}
