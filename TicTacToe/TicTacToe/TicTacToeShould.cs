using System;
using System.Collections.Generic;
using Xunit;

namespace TicTacToe;

public class TicTacToeShould
{
    private readonly Game game;

    public TicTacToeShould()
    {
        game = new Game();
    }

    [Fact]
    public void AlwaysStartWithPlayerX()
    {
        Action action = () => game.Place(BoardPosition.Position1, Symbol.O);
        Assert.Throws<MustBeginGameWithPlayerXException>(action);
    }

    [Fact]
    public void AlternatePlacedSymbols()
    {
        game.Place(BoardPosition.Position1, Symbol.X);
        game.Place(BoardPosition.Position2, Symbol.O);

        Assert.True(true);
    }

    [Fact]
    public void NotPlacedSameSymbolSequentially()
    {
        game.Place(BoardPosition.Position1, Symbol.X);

        Action action = () => game.Place(BoardPosition.Position2, Symbol.X);

        Assert.Throws<PlayersMustAlternateException>(action);
    }

    [Fact]
    public void NotPlaceSymbolsOnAlreadyTakenPosition()
    {
        game.Place(BoardPosition.Position1, Symbol.X);
        game.Place(BoardPosition.Position2, Symbol.O);

        Action action = () => game.Place(BoardPosition.Position1, Symbol.X);
        
        Assert.Throws<CannotPlaceOnOccupiedPositionException>(action);
    }

    [Fact]
    public void ThreeEqualSymbolsInHorizontalRowWin()
    {
        game.Place(BoardPosition.Position0, Symbol.X);
        game.Place(BoardPosition.Position3, Symbol.O);
        game.Place(BoardPosition.Position1, Symbol.X);
        game.Place(BoardPosition.Position4, Symbol.O);
        game.Place(BoardPosition.Position2, Symbol.X);

        Assert.Equal(GameResult.XWins, game.Result);
    }

    [Fact]
    public void ThreeEqualSymbolsInVerticalRowWin()
    {
        game.Place(BoardPosition.Position0, Symbol.X);
        game.Place(BoardPosition.Position1, Symbol.O);
        game.Place(BoardPosition.Position3, Symbol.X);
        game.Place(BoardPosition.Position2, Symbol.O);
        game.Place(BoardPosition.Position6, Symbol.X);

        Assert.Equal(GameResult.XWins, game.Result);
    }

    [Fact]
    public void ThreeEqualSymbolsInTopToBottomDiagonalRowWin()
    {
        game.Place(BoardPosition.Position0, Symbol.X);
        game.Place(BoardPosition.Position1, Symbol.O);
        game.Place(BoardPosition.Position4, Symbol.X);
        game.Place(BoardPosition.Position5, Symbol.O);
        game.Place(BoardPosition.Position8, Symbol.X);

        Assert.Equal(GameResult.XWins, game.Result);
    }

    [Fact]
    public void ThreeEqualSymbolsInBottomToTopDiagonalRowWin()
    {
        game.Place(BoardPosition.Position2, Symbol.X);
        game.Place(BoardPosition.Position3, Symbol.O);
        game.Place(BoardPosition.Position4, Symbol.X);
        game.Place(BoardPosition.Position5, Symbol.O);
        game.Place(BoardPosition.Position6, Symbol.X);

        Assert.Equal(GameResult.XWins, game.Result);
    }

    [Fact]
    public void FinishedDrawGameCannotBePlayed()
    {
        game.Place(BoardPosition.Position0, Symbol.X);
        game.Place(BoardPosition.Position1, Symbol.O);
        game.Place(BoardPosition.Position2, Symbol.X);
        game.Place(BoardPosition.Position4, Symbol.O);
        game.Place(BoardPosition.Position3, Symbol.X);
        game.Place(BoardPosition.Position6, Symbol.O);
        game.Place(BoardPosition.Position5, Symbol.X);
        game.Place(BoardPosition.Position8, Symbol.O);
        game.Place(BoardPosition.Position7, Symbol.X);

        Action action = () => game.Place(BoardPosition.Position0, Symbol.O);

        Assert.Throws<GameAlreadyFinishedException>(action);
    }

    [Fact]
    public void FinishedWonGameCannotBePlayed()
    {
        game.Place(BoardPosition.Position2, Symbol.X);
        game.Place(BoardPosition.Position3, Symbol.O);
        game.Place(BoardPosition.Position4, Symbol.X);
        game.Place(BoardPosition.Position5, Symbol.O);
        game.Place(BoardPosition.Position6, Symbol.X);

        Action action = () => game.Place(BoardPosition.Position0, Symbol.O);

        Assert.Throws<GameAlreadyFinishedException>(action);
    }
}

public class MustBeginGameWithPlayerXException: Exception
{
}

public class GameAlreadyFinishedException: Exception
{
}

public class CannotPlaceOnOccupiedPositionException : Exception
{
}

public class PlayersMustAlternateException: Exception
{
}

public enum GameResult
{
    Playing,
    XWins,
    OWins,
    Draw
}

public enum Symbol
{
    X,
    O
}

public enum BoardPosition
{
    Position0,
    Position1,
    Position2,
    Position3,
    Position4,
    Position5,
    Position6,
    Position7,
    Position8
}

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

internal class Board
{
    private const int Size = 9;
    private readonly Dictionary<BoardPosition, Symbol> positions = new(Size);
    public bool Full { get; private set; }

    public bool Contains(BoardPosition position)
    {
        return positions.ContainsKey(position);
    }

    public void Set(BoardPosition position, Symbol symbol)
    {
        positions[position] = symbol;
        Full = positions.Count == Size;
    }

    public Symbol? At(BoardPosition position)
    {
        return positions.ContainsKey(position) ? positions[position] : null;
    }
}