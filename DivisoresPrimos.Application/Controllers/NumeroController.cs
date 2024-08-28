using DivisoresPrimos.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DivisoresPrimos.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeroController : ControllerBase
    {
        private readonly INumberServices _numeroService;

        public NumeroController(INumberServices numeroService)
        {
            _numeroService = numeroService;
        }

        [HttpGet("{valor}/divisores")]
        public IActionResult ObterDivisores(int valor)
        {
            var divisores = _numeroService.GetDivisors(valor);
            return Ok(divisores);
        }

        [HttpGet("{valor}/divisoresprimos")]
        public IActionResult ObterDivisoresPrimos(int valor)
        {
            var divisores = _numeroService.GetDivisors(valor);
            var divisoresPrimos = _numeroService.GetPrimeDivisors(divisores);
            return Ok(divisoresPrimos);
        }
    }
}
