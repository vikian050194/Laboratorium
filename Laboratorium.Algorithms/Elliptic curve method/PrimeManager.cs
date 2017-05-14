using Laboratorium.Algorithms.Integer_arithmetic;
using Laboratorium.Algorithms.Integer_arithmetic.Eratosthenes_sieve;

namespace Laboratorium.Algorithms.Elliptic_curve_method
{
    public class PrimeManager
    {

        ulong _low,_sieveStep;
        int _currentIndex;
        ulong[] _primes;
        EratosthenesSieve _sieve;

        public ulong NextPrime()
        {
            if (_currentIndex==_primes.Length)
            {
                _low += _sieveStep;
                _primes = _sieve.GetPrimes(_low+1, _low + _sieveStep);
                _currentIndex = 0;

            }
            return _primes[_currentIndex++];
        }

        public void Init(ulong start)
        {
            _low = start;
            _sieveStep = 10000000;
            _sieve=new EratosthenesSieve();
            _primes = _sieve.GetPrimes(_low, _low + _sieveStep);
            _currentIndex = 0;
        }
    }
}
