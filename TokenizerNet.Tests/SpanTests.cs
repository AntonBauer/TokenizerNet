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
            var first = new CodeSpan(new byte[] { 0, 41}, new byte[] { 0, 90 });
            var second = new CodeSpan(new byte[] { 0, 84 });
            var third = new CodeSpan(new byte[] { 5, 208 }, new byte[] { 5, 234 });
            var fourth = new CodeSpan(new byte[] { 251, 29 });

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
