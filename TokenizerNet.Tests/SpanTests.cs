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

            //fb1d

            // Act
            var result_1 = first.Contains(second);
            var result_2 = third.Contains(second);
            var result_3 = fourth.Contains(second);

            // Assert
            Assert.IsTrue(result_1);
            Assert.IsFalse(result_2);
            Assert.IsFalse(result_3);
        }
    }
}
