using DivisoresPrimos.Application.Controllers;
using DivisoresPrimos.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DivisoresPrimos.Tests
{
    public class NumeroControllerTests
    {
        private readonly Mock<INumberServices> _mockService;
        private readonly NumeroController _controller;

        public NumeroControllerTests()
        {
            _mockService = new Mock<INumberServices>();
            _controller = new NumeroController(_mockService.Object);
        }

        [Fact]
        public void ObterDivisores_DeveRetornarOkComDivisores()
        {
            // Arrange
            int valor = 6;
            var divisoresEsperados = new List<int> { 1, 2, 3, 6 };
            _mockService.Setup(s => s.GetDivisors(valor)).Returns(divisoresEsperados);

            // Act
            var result = _controller.ObterDivisores(valor) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(divisoresEsperados, result.Value);
        }

        [Fact]
        public void ObterDivisoresPrimos_DeveRetornarOkComDivisoresPrimos()
        {
            // Arrange
            int valor = 6;
            var divisoresPrimosEsperados = new List<int> { 2, 3 };
            var divisores = new List<int>();

            _mockService.Setup(s => s.GetDivisors(valor)).Returns(divisores);
            _mockService.Setup(s => s.GetPrimeDivisors(divisores)).Returns(divisoresPrimosEsperados);

            // Act
            var result = _controller.ObterDivisoresPrimos(valor) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(divisoresPrimosEsperados, result.Value);
        }
    }
}
