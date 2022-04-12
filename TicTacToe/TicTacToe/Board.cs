using System;
using System.Collections.Generic;

namespace TicTacToe;

internal class Board
{
    private readonly Dictionary<BoardPosition, Symbol> positions = new(Enum.GetValues(typeof(BoardPosition)).Length);
    public Symbol? LastSymbolPlayed { get; private set; }

    public bool IsFull()
    {
        return positions.Count == Enum.GetValues(typeof(BoardPosition)).Length;
    }

    public void Set(BoardPosition position, Symbol symbol)
    {
        if (positions.ContainsKey(position)) throw new CannotPlaceOnOccupiedPositionException();

        positions[position] = symbol;
        LastSymbolPlayed = symbol;
    }

    public bool ThreeInRow()
    {
        return Horizontally() || Vertically() || TopToBottomDiagonal() || BottomToTopDiagonal();
    }

    private bool BottomToTopDiagonal()
    {
        return
            At(BoardPosition.Position2) == LastSymbolPlayed &&
            At(BoardPosition.Position4) == LastSymbolPlayed &&
            At(BoardPosition.Position6) == LastSymbolPlayed;
    }

    private bool TopToBottomDiagonal()
    {
        return
            At(BoardPosition.Position0) == LastSymbolPlayed &&
            At(BoardPosition.Position4) == LastSymbolPlayed &&
            At(BoardPosition.Position8) == LastSymbolPlayed;
    }

    private bool Vertically()
    {
        return
            (At(BoardPosition.Position0) == LastSymbolPlayed &&
             At(BoardPosition.Position3) == LastSymbolPlayed &&
             At(BoardPosition.Position6) == LastSymbolPlayed)
            ||
            (At(BoardPosition.Position1) == LastSymbolPlayed &&
             At(BoardPosition.Position4) == LastSymbolPlayed &&
             At(BoardPosition.Position7) == LastSymbolPlayed)
            ||
            (At(BoardPosition.Position2) == LastSymbolPlayed &&
             At(BoardPosition.Position5) == LastSymbolPlayed &&
             At(BoardPosition.Position8) == LastSymbolPlayed);
    }

    private bool Horizontally()
    {
        return
            (At(BoardPosition.Position0) == LastSymbolPlayed &&
             At(BoardPosition.Position1) == LastSymbolPlayed &&
             At(BoardPosition.Position2) == LastSymbolPlayed)
            ||
            (At(BoardPosition.Position3) == LastSymbolPlayed &&
             At(BoardPosition.Position4) == LastSymbolPlayed &&
             At(BoardPosition.Position5) == LastSymbolPlayed)
            ||
            (At(BoardPosition.Position6) == LastSymbolPlayed &&
             At(BoardPosition.Position7) == LastSymbolPlayed &&
             At(BoardPosition.Position8) == LastSymbolPlayed);
    }

    private Symbol? At(BoardPosition position)
    {
        return positions.ContainsKey(position) ? positions[position] : null;
    }

}