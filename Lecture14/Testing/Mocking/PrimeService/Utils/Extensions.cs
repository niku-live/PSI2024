using Prime.Models;
using Prime.DTO;

namespace Prime.Utils
{
    public static class Extensions
    {
        public static NumberInfo ToNumberInfo(this PrimeResult primeResult)
        {
            return new NumberInfo
            {
                Number = primeResult.Number,
                IsPrime = primeResult.IsPrime,
                AdditionalInformation = primeResult.AdditionalInformation
            };
        }

        public static PrimeResult ToPrimeResult(this NumberInfo numberInfo)
        {
            return new PrimeResult(numberInfo.Number, numberInfo.IsPrime, numberInfo.AdditionalInformation);
        }
    }
}