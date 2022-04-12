using System;
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