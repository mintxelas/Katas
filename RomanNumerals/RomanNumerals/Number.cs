using System.Reflection.Metadata;

namespace RomanNumerals;

public class Number
{

    private static readonly string[] Symbols =
    {
        string.Empty,
        @"I" , 
        @"II" , 
        @"III", 
        @"IV", 
        @"V", 
        @"IX",
        @"X", 
        @"XL",
        @"L",
        @"XC",
        @"C",
        @"CD"
    };
    
    private static readonly (int, int)[] Values =
    {
        (400, 12), 
        (100, 11), 
        (90, 10), 
        (50, 9), 
        (40, 8), 
        (10, 7), 
        (9, 6), 
        (5, 5)
    };

    private readonly int arabic;

    public Number(int arabic)
    {
        this.arabic = arabic;
    }

    public string ToRoman()
    {
        foreach (var (limit, index) in Values)
        {
            if (arabic >= limit)
                return Symbols[index] + new Number(arabic - limit).ToRoman();
        }
        return Symbols[arabic];
    }
}