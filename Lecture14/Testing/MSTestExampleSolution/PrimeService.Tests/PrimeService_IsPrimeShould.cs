using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            // Arrange

            // Act
            var result = _primeService.IsPrime(1);

            // Assert
            Assert.IsFalse(result, $"1 should not be prime");
        }

        #region Sample_TestCode
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            // Arrange

            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion

        #region Sample_TestCodeCover2
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        public void IsPrime_SimplePrimeNumbers_ReturnTrue(int value)
        {
            // Arrange

            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.IsTrue(result, $"{value} should be prime");
        }
        #endregion

        #region Sample_TestCodeCover3
        [DataTestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(9)]
        public void IsPrime_SimpleNonPrimeNumbers_ReturnFalse(int value)
        {
            // Arrange

            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.IsFalse(result, $"{value} should not be prime");
        }
        #endregion
    }
}