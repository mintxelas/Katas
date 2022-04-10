using Xunit;

namespace BowlingKata;

public class BowlingScoreCalculator1Should
{
    [Theory]
    [InlineData(new[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300)]
    [InlineData(new[] { 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0, 9, 0 }, 90)]
    [InlineData(new[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 150)]
    [InlineData(new[] { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 }, 167)]
    public void CalculateScore(int[] tries, int score)
    {
        var actual = Score(tries);
        Assert.Equal(score, actual);
    }
    
    private int Score(int[] tries)
    {
        var totalScore = 0;
        var i = 0;
        for (var frame = 0; frame < 10; frame++)
        {
            totalScore += tries[i] + tries[i + 1];

            if (tries[i] == 10)
            {
                totalScore += tries[i + 2];
                i += 1;
                continue;
            }

            if (tries[i] + tries[i + 1] == 10)
            {
                totalScore += tries[i + 2];
            }

            i += 2;
        }

        return totalScore;
    }
}
