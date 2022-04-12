using System.Collections.Generic;

namespace TicTacToe;

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