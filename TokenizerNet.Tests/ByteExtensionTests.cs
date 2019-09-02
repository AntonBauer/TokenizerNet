using NUnit.Framework;
using TokenizerNet.Utils;

namespace TokenizerNet.Tests
{
    [TestFixture]
    [Category("Byte extensions")]
    public sealed class ByteExtensionTests
    {
        [Test]
        public void IsGreaterThanTest()
        {
            // Arrange
            var first = new byte[] { 0, 84 };
            var second = new byte[] { 0, 41 };
            var third = new byte[] { 5, 208 };

            // Act
            var result_1 = first.IsGreaterThan(second);
            var result_2 = first.IsGreaterThan(third);

            // Assert
            Assert.IsTrue(result_1);
            Assert.IsFalse(result_2);
        }

        [Test]
        public void IsLessThanTest()
        {
            // Arrange
            var first = new byte[] { 0, 84 };
            var second = new byte[] { 0, 90 };
            var third = new byte[] { 5, 208 };
            var fourth = new byte[] { 251, 29 };

            // Act
            var result_1 = first.IsLessThan(second);
            var result_2 = third.IsLessThan(first);
            var result_3 = fourth.IsLessThan(first);

            // Assert
            Assert.IsTrue(result_1);
            Assert.IsFalse(result_2);
            Assert.IsFalse(result_3);
        }

        [Test]
        public void IsEqualToTest()
        {
            // Arrange
            var first = new byte[] { 0, 84 };
            var second = new byte[] { 0, 84 };
            var third = new byte[] { 0, 12 };

            // Act
            var firstSecond = first.IsEqualTo(second);
            var secondThird = second.IsEqualTo(third);

            // Assert
            Assert.IsTrue(firstSecond);
            Assert.IsFalse(secondThird);
        }
    }
}
