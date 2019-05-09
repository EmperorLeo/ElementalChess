using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : BasePiece
{
    private bool movedBefore;

    public override string MoveTo(ChessSquare square, BasePiece[][] pieces)
    {
        var letter = square.Column.ToString().ToLower();
        movedBefore = true;
        return $"{letter}{base.MoveTo(square, pieces)}";
    }

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces)
    {
        var moves = new List<ChessSquare>();
        
        var curCol = currentSquare.Column - 65;
        var curRow = currentSquare.Row - 1;

        if (Team == 1)
        {
            if (curCol < 7 && pieces[curRow + 1][curCol + 1] != null && pieces[curRow + 1][curCol + 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow + 1, (char)(curCol + 1)));
            }

            if (curCol > 0 && pieces[curRow + 1][curCol - 1] != null && pieces[curRow + 1][curCol - 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow + 1, (char)(curCol - 1)));
            }

            if (pieces[curRow + 1][curCol] == null)
            {
                moves.Add(new ChessSquare(curRow + 1, currentSquare.Column));
            }
        }
        else
        {
            if (curCol < 7 && pieces[curRow - 1][curCol + 1] != null && pieces[curRow - 1][curCol + 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow - 1, (char)(curCol + 1)));
            }

            if (curCol > 0 && pieces[curRow - 1][curCol - 1] != null && pieces[curRow - 1][curCol - 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow - 1, (char)(curCol - 1)));
            }
            moves.Add(new ChessSquare(curRow - 1, currentSquare.Column));
        }

        if (!movedBefore && pieces[curRow + 2][curCol] == null)
        {
            moves.Add(new ChessSquare(currentSquare.Row + 2, currentSquare.Column));
        }

        return moves;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
