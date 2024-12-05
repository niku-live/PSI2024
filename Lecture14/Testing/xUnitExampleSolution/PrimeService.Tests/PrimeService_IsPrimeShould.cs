using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            // Arrange
            var primeService = new PrimeService();
            
            // Act
            bool result = primeService.IsPrime(1);

            // Assert
            Assert.False(result, "1 should not be prime");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            // Arrange
            
            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.False(result, $"{value} should not be prime");
        }
    }
}