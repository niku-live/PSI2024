using Prime.Data;
using Prime.Models;

namespace Prime.Repositories
{
    public class PrimeRepository: IPrimeRepository
    {
        PrimeDbContext _primeDbContext;

        public PrimeRepository(PrimeDbContext primeDbContext)
        {
            _primeDbContext = primeDbContext;
        }

        public bool Has(int candidate)
        {
            return _primeDbContext.Numbers.Any(primeResult => primeResult.Number == candidate);
        }

        public NumberInfo Get(int candidate)
        {
            return _primeDbContext.Numbers.First(primeResult => primeResult.Number == candidate);
        }

        public void Add(NumberInfo number)
        {
            _primeDbContext.Numbers.Add(number);
            _primeDbContext.SaveChanges();
        }
    }
}