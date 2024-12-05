using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prime.Controllers;
using Prime.Data;
using Prime.DTO;
using Prime.Repositories;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {            
            // Arrange
            var options = new DbContextOptionsBuilder<PrimeDbContext>().UseInMemoryDatabase("TestDb").Options;
            var primeContenxt = new PrimeDbContext(options);
            var primeRepository = new PrimeRepository(primeContenxt);
            var _primeService = new PrimeService(primeRepository);

            // Act
            var result = _primeService.IsPrime(1);

            // Assert
            Assert.IsFalse(result.IsPrime, $"1 should not be prime");
        }

        #region Sample_TestCode
        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            // Arrange
            var services = new ServiceCollection();

            // Using In-Memory database for testing
            services.AddDbContext<PrimeDbContext>(options => options.UseInMemoryDatabase("TestDb"));

            services.AddScoped<IPrimeRepository, PrimeRepository>();
            services.AddScoped<IPrimeService, PrimeService>();

            var _serviceProvider = services.BuildServiceProvider();
            using (var scope = _serviceProvider.CreateScope())
            {

                var scopedServices = scope.ServiceProvider;
                var _primeService = scopedServices.GetRequiredService<IPrimeService>();

                // Act
                var result = _primeService.IsPrime(value);

                // Assert
                Assert.IsFalse(result.IsPrime, $"{value} should not be prime");
            }
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
            var primeRepository = new Mock<IPrimeRepository>();
            primeRepository.Setup(x => x.Has(It.IsAny<int>())).Returns(false);
            var _primeService = new PrimeService(primeRepository.Object);

            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.IsTrue(result.IsPrime, $"{value} should be prime");
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
            var primeRepository = new Mock<IPrimeRepository>();
            primeRepository.Setup(x => x.Has(It.IsAny<int>())).Returns(false);
            var _primeService = new PrimeService(primeRepository.Object);

            // Act
            var result = _primeService.IsPrime(value);

            // Assert
            Assert.IsFalse(result.IsPrime, $"{value} should not be prime");
        }        
        #endregion

        [TestMethod]
        public void TestController_ReturnsOk()
        {
            // Arrange
            var primeService = new Mock<IPrimeService>();
            primeService.Setup(x => x.IsPrime(It.IsAny<int>())).Returns(new PrimeResult(1, false, "Number must be greater than 1"));
            var controller = new PrimeController(primeService.Object);

            // Act
            var result = controller.IsPrime(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }        
    }
}