namespace TicTacToe;

public class Game
{
    private readonly Board board = new();
    public GameResult Result { get; private set; } = GameResult.Playing;
    
    public void Place(BoardPosition position, Symbol symbol)
    {
        if (Result != GameResult.Playing) throw new GameAlreadyFinishedException();
        if (!board.LastSymbolPlayed.HasValue && symbol != Symbol.X) throw new MustBeginGameWithPlayerXException();
        if (board.LastSymbolPlayed == symbol) throw new PlayersMustAlternateException();
        board.Set(position, symbol);
        CalculateGameResult();
    }

    private void CalculateGameResult()
    {
        if (board.ThreeInRow())
        {
            Result = board.LastSymbolPlayed == Symbol.X ? GameResult.XWins : GameResult.OWins;
        }

        if (Result == GameResult.Playing && board.IsFull())
        {
            Result = GameResult.Draw;
        }
    }
}