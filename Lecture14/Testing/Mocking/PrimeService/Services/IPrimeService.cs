using System;
using Prime.DTO;

namespace Prime.Services
{
    public interface IPrimeService
    {
        PrimeResult IsPrime(int candidate);
    }
}