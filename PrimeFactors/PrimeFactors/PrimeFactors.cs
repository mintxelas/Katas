using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors;

public class PrimeFactors
{
    private static readonly int[] primes = { 2, 3, 5, 7, 11 };

    public int[] GetPrimeFactors(int number)
    {
        if (number == 1) return new int[] { };
        var factor = GetSmallestFactor(number);
        return Concatenate(factor, GetPrimeFactors(number / factor));
    }

    private IEnumerable<int> PrimesEnum()
    {
        int i = 2;
        while (i < int.MaxValue)
        {
            if (Enumerable.Range(2, i - 2).All(n => i % n != 0))
                yield return i;
            i++;
        }
    }

    private int GetSmallestFactor(int number)
    {
        foreach (var prime in PrimesEnum())
        {
            if (number % prime == 0) return prime;
        }

        throw new ArgumentOutOfRangeException(nameof(number), "number too big for me.");
    }

    private static bool IsPrime(int number)
    {
        return primes.Contains(number);
    }

    private int[] Concatenate(int start, int[] rest)
    {
        var l = new List<int> { start };
        l.AddRange(rest);
        return l.ToArray();
    }
}