namespace TicTacToe;

public class Game
{
    private readonly Board board = new();
    private Symbol? lastSymbolPlayed;
    public GameResult Result { get; private set; } = GameResult.Playing;
    
    public void Place(BoardPosition position, Symbol symbol)
    {
        if (Result != GameResult.Playing) throw new GameAlreadyFinishedException();
        if (!lastSymbolPlayed.HasValue && symbol != Symbol.X) throw new MustBeginGameWithPlayerXException();
        if (lastSymbolPlayed == symbol) throw new PlayersMustAlternateException();
        if (Taken(position)) throw new CannotPlaceOnOccupiedPositionException();
        Occupy(position, symbol);
        lastSymbolPlayed = symbol;
        CalculateGameResult();
    }

    private void CalculateGameResult()
    {
        if (Horizontally() || Vertically() || TopToBottomDiagonal() || BottomToTopDiagonal())
        {
            Result = lastSymbolPlayed == Symbol.X ? GameResult.XWins : GameResult.OWins;
        }

        if (Result == GameResult.Playing && board.Full)
        {
            Result = GameResult.Draw;
        }
    }

    private bool BottomToTopDiagonal()
    {
        return
            board.At(BoardPosition.Position2) == lastSymbolPlayed &&
            board.At(BoardPosition.Position4) == lastSymbolPlayed &&
            board.At(BoardPosition.Position6) == lastSymbolPlayed;
    }

    private bool TopToBottomDiagonal()
    {
        return
            board.At(BoardPosition.Position0) == lastSymbolPlayed &&
            board.At(BoardPosition.Position4) == lastSymbolPlayed &&
            board.At(BoardPosition.Position8) == lastSymbolPlayed;
    }

    private bool Vertically()
    {
        return
            (board.At(BoardPosition.Position0) == lastSymbolPlayed &&
             board.At(BoardPosition.Position3) == lastSymbolPlayed &&
             board.At(BoardPosition.Position6) == lastSymbolPlayed)
            ||
            (board.At(BoardPosition.Position1) == lastSymbolPlayed &&
             board.At(BoardPosition.Position4) == lastSymbolPlayed &&
             board.At(BoardPosition.Position7) == lastSymbolPlayed)
            ||
            (board.At(BoardPosition.Position2) == lastSymbolPlayed &&
             board.At(BoardPosition.Position5) == lastSymbolPlayed &&
             board.At(BoardPosition.Position8) == lastSymbolPlayed);
    }

    private bool Horizontally()
    {
        return
            (board.At(BoardPosition.Position0) == lastSymbolPlayed &&
             board.At(BoardPosition.Position1) == lastSymbolPlayed &&
             board.At(BoardPosition.Position2) == lastSymbolPlayed)
            ||
            (board.At(BoardPosition.Position3) == lastSymbolPlayed &&
             board.At(BoardPosition.Position4) == lastSymbolPlayed &&
             board.At(BoardPosition.Position5) == lastSymbolPlayed)
            ||
            (board.At(BoardPosition.Position6) == lastSymbolPlayed &&
             board.At(BoardPosition.Position7) == lastSymbolPlayed &&
             board.At(BoardPosition.Position8) == lastSymbolPlayed);
    }

    private void Occupy(BoardPosition position, Symbol symbol)
    {
        board.Set(position, symbol);
    }

    private bool Taken(BoardPosition position)
    {
        return board.Contains(position);
    }
}