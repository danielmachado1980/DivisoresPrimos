
using DivisoresPrimos.Application.Controllers;
using DivisoresPrimos.Infra.Contracts;
using DivisoresPrimos.Services;
using Microsoft.Extensions.Caching.Memory;
using Moq;

namespace DivisoresPrimos.Tests
{
    public class NumeroServiceTests
    {
        private readonly Mock<IMemoryCache> _mockCache;
        private readonly NumberServices _service;

        public NumeroServiceTests()
        {
            _mockCache = new Mock<IMemoryCache>();
            _service = new NumberServices(_mockCache.Object);
        }


        [Fact]
        public void ObterDivisores_DeveRetornarOkComDivisores()
        {
            // Arrange
            int input = 12;
            List<int> expectedDivisors = new List<int> { 1, 2, 3, 4, 6, 12 };

            object cacheEntry = null;
            _mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out cacheEntry)).Returns(false);
            _mockCache.Setup(mc => mc.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            // Act
            var result = _service.GetDivisors(input);

            // Assert
            Assert.Equal(expectedDivisors, result);
        }

        [Fact]
        public void ObterDivisoresPrimos_DeveRetornarOkComDivisoresPrimos()
        {
            // Arrange
            List<int> divisors = new List<int> { 1, 2, 3, 4, 6, 12 };
            List<int> expectedPrimeDivisors = new List<int> { 2, 3 };

            object cacheEntry = null;
            _mockCache.Setup(mc => mc.TryGetValue(It.IsAny<object>(), out cacheEntry)).Returns(false);
            _mockCache.Setup(mc => mc.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>());

            // Act
            var result = _service.GetPrimeDivisors(divisors);

            // Assert
            Assert.Equal(expectedPrimeDivisors, result);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(10, false)]
        public void Primo_DeveRetornarSePrimo(int input, bool expected)
        {
            // Act
            var result = _service.IsPrime(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}