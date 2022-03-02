namespace FizzBuzz;

public class FizzBuzz
{
    public string Write(int number)
    {
        var result = string.Empty;
        if (IsMultipleOf(number, 3)) result += "Fizz";
        if (IsMultipleOf(number, 5)) result += "Buzz";
        if (string.IsNullOrEmpty(result)) result = number.ToString();
        return result;
    }

    private bool IsMultipleOf(int number, int divider)
    {
        return number % divider == 0;
    }

}