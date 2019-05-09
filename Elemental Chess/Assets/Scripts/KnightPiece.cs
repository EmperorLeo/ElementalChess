using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPiece : BasePiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces)
    {
        var moves = new List<ChessSquare>(8);
        var column = currentSquare.Column - 65;
        var row = currentSquare.Row - 1;

        Debug.Log($"Knight is at Row {row} and Column {column}");
        if (column > 0 && row < 6 && (pieces[row + 2][column - 1] == null || pieces[row + 2][column - 1].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row + 2, (char)(currentSquare.Column - 1)));
        }

        if (column > 0 && row > 1 && (pieces[row - 2][column - 1] == null || pieces[row - 2][column - 1].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row - 2, (char)(currentSquare.Column - 1)));
        }

        if (column < 7 && row < 6 && (pieces[row + 2][column + 1] == null || pieces[row + 2][column + 1].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row + 2, (char)(currentSquare.Column + 1)));
        }

        if (column < 7 && row > 1 && (pieces[row - 2][column + 1] == null || pieces[row - 2][column + 1].Team != Team))
        {
            moves.Add(new ChessSquare((char)(currentSquare.Row - 2), (char)(currentSquare.Column + 1)));
        }

        if (column > 1 && row < 7 && (pieces[row + 1][column - 2] == null || pieces[row + 1][column - 2].Team != Team))
        {
            moves.Add(new ChessSquare((char)(currentSquare.Row + 1), (char)(currentSquare.Column - 2)));
        }

        if (column > 1 && row > 0 && (pieces[row - 1][column - 2] == null || pieces[row - 1][column - 2].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row - 1, (char)(currentSquare.Column - 2)));
        }

        if (column < 6 && row < 7 && (pieces[row + 1][column + 2] == null || pieces[row + 1][column + 2].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row + 1, (char)(currentSquare.Column + 2)));
        }

        if (column < 6 && row > 0 && (pieces[row - 1][column + 2] == null || pieces[row - 1][column + 2].Team != Team))
        {
            moves.Add(new ChessSquare(currentSquare.Row - 1, (char)(currentSquare.Column + 2)));
        }

        return moves;
    }
}
