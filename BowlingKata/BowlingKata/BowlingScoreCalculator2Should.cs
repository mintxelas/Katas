using System;
using System.Collections;
using Xunit;

namespace BowlingKata;

public class BowlingScoreCalculator2Should
{
    [Theory]
    [InlineData(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300)]
    [InlineData(new[] { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0 }, 90)]
    [InlineData(new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 150)]
    [InlineData(new[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 }, 167)]
    public void CalculateScore(int[] tries, int score)
    {
        var calculator = new Calculator(tries);
        var actual = calculator.Score();
        Assert.Equal(score, actual);
    }
}

public class Calculator
{
    private readonly int[] tries;

    public Calculator(int[] tries)
    {
        this.tries = tries;
    }

    public int NextFrameIndex(int currentFrameIndex)
    {
        if (tries[currentFrameIndex] == 10) return currentFrameIndex + 1;
        return currentFrameIndex + 2;
    }

    public int FramePoints(int i)
    {
        var total = tries[i] + tries[i + 1];
        if (total >= 10) total += tries[i + 2];
        return total;
    }

    public int Score()
    {
        var totalScore = 0;
        var currentFrameIndex = 0;
        10.Times(i =>
        {
            totalScore += FramePoints(currentFrameIndex);
            currentFrameIndex = NextFrameIndex(currentFrameIndex);
        });
        return totalScore;
    }

}

public static class IntExtensions
{
    public static void Times(this int times, Action<int> action)
    {
        for (var i = 0; i < times; i++)
        {
            action(i);
        }
    }
}
