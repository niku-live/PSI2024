using Prime.DTO;
using Prime.Repositories;
using Prime.Utils;

namespace Prime.Services
{
    public class PrimeService: IPrimeService
    {
         private IPrimeRepository _primeRepository;

         public PrimeService(IPrimeRepository primeRepository)
         {
             _primeRepository = primeRepository;
         }

        public PrimeResult IsPrime(int candidate)
        {
            if (_primeRepository.Has(candidate))
            {
                return _primeRepository.Get(candidate).ToPrimeResult();
            }

            var result = CalculateIsPrime(candidate);
            _primeRepository.Add(result.ToNumberInfo());
            return result;
        }

        private static PrimeResult CalculateIsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return new PrimeResult(candidate, false, "Number must be greater than 1");
            }

            for (var divisor = 2; divisor <= Math.Sqrt(candidate); divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return new PrimeResult(candidate, false, $"Divisible by {divisor}");
                }
            }
            return new PrimeResult(candidate, true, "The number is prime");
        }
    }
}