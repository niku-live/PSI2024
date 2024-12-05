#region Sample_FirstTest
using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private PrimeService? _primeService;

        [SetUp]
        public void SetUp()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            // Arrange

            // Act
            var result = _primeService?.IsPrime(1);

            // Assert
            Assert.IsFalse(result, "1 should not be prime");
        }
        #endregion

        #region Sample_TestCode
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            // Arrange
            
            // Act
            var result = _primeService?.IsPrime(value);

            // Assert
            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion
    }
}