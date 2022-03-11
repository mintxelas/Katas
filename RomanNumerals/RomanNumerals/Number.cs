namespace RomanNumerals;

public class Number
{

    private static readonly (int, string)[] Symbols =
        {
        (400, @"CD"),
        (100, @"C"),
        (90, @"XC"),
        (50, @"L"),
        (40, @"XL"),
        (10, @"X"),
        (9, @"IX"),
        (5, @"V"),
        (4, @"IV"),
        (3, @"III"),
        (2, @"II"),
        (1, @"I"),
        (0, string.Empty),
    };

    private readonly int arabic;

    public Number(int arabic)
    {
        this.arabic = arabic;
    }

    public string ToRoman()
    {
        foreach (var (limit, symbol) in Symbols)
        {
            if (arabic > 5 && arabic >= limit)
            {
                return symbol + new Number(arabic - limit).ToRoman();
            }
        }
        var (_, sym) = Symbols[Symbols.Length - arabic - 1];
        return sym;
    }
}