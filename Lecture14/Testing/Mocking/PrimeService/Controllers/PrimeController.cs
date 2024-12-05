using Microsoft.AspNetCore.Mvc;
using Prime.Services;

namespace Prime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeController: ControllerBase
    {
        private readonly IPrimeService _primeService;

        public PrimeController(IPrimeService primeService)
        {
            _primeService = primeService;
        }

        [HttpGet("{number}")]
        public ActionResult IsPrime(int number)
        {
            return Ok(_primeService.IsPrime(number));
        }
    }
}