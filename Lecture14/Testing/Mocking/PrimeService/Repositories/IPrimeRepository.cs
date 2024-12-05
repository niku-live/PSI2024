using Prime.Models;

namespace Prime.Repositories
{
    public interface IPrimeRepository
    {
        bool Has(int candidate);
        void Add(NumberInfo primeResult);
        NumberInfo Get(int number);
    }
}