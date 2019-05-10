using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPiece : BasePiece
{
    private bool movedBefore;

    public override string MoveTo(ChessSquare square, BasePiece[][] pieces, bool isBuffed)
    {
        var letter = square.Column.ToString().ToLower();
        movedBefore = true;
        return $"{letter}{base.MoveTo(square, pieces, isBuffed)}";
    }

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces, int? element, int[][] elementalSquares)
    {
        var moves = new List<ChessSquare>();
        
        var curCol = currentSquare.Column - 65;
        var curRow = currentSquare.Row - 1;

        if (Team == 1)
        {
            if (curCol < 7 && pieces[curRow + 1][curCol + 1] != null && pieces[curRow + 1][curCol + 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow + 2, (char)(currentSquare.Column + 1)));
            }

            if (curCol > 0 && pieces[curRow + 1][curCol - 1] != null && pieces[curRow + 1][curCol - 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow + 2, (char)(currentSquare.Column - 1)));
            }

            if (pieces[curRow + 1][curCol] == null)
            {
                moves.Add(new ChessSquare(curRow + 2, currentSquare.Column));
            }

            if (!movedBefore && pieces[curRow + 2][curCol] == null)
            {
                moves.Add(new ChessSquare(currentSquare.Row + 2, currentSquare.Column));
            }
        }
        else
        {
            if (curCol < 7 && pieces[curRow - 1][curCol + 1] != null && pieces[curRow - 1][curCol + 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow, (char)(currentSquare.Column + 1)));
            }

            if (curCol > 0 && pieces[curRow - 1][curCol - 1] != null && pieces[curRow - 1][curCol - 1].Team != Team)
            {
                moves.Add(new ChessSquare(curRow, (char)(currentSquare.Column - 1)));
            }

            if (pieces[curRow - 1][curCol] == null)
            {
                moves.Add(new ChessSquare(curRow, currentSquare.Column));
            }

            if (!movedBefore && pieces[curRow - 2][curCol] == null)
            {
                moves.Add(new ChessSquare(currentSquare.Row - 2, currentSquare.Column));
            }
        }

        if (element.HasValue && element.Value == elementalSquares[curRow][curCol])
        {
            switch (element.Value)
            {
                case 0:
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            if (i != 0 && j != 0 && curRow + i >= 0 && curRow + i < 8 && curCol + j >= 0 && curCol + j < 8)
                            {
                                if (pieces[curRow + i][curCol + j] == null || pieces[curRow + i][curCol + j].Team != Team)
                                {
                                    // Will add duplicates sometimes
                                    moves.Add(new ChessSquare(curRow + i + 1, (char)(curCol + j + 65)));
                                }
                            }
                        }
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                default:
                    break;
            }
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
