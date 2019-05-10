using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookPiece : BasePiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces, int? element, int[][] elementalSquares)
    {
        var moves = new List<ChessSquare>();
        var column = currentSquare.Column - 65;
        var row = currentSquare.Row - 1;

        var topIncr = row;
        var bottomIncr = row;
        var leftIncr = column;
        var rightIncr = column;
        while (topIncr < 7 && (pieces[topIncr + 1][column] == null || pieces[topIncr + 1][column].Team != Team))
        {
            topIncr++;
            moves.Add(new ChessSquare(topIncr + 1, currentSquare.Column));
            if (pieces[topIncr][column] != null)
            {
                break;
            }
        }

        while (bottomIncr > 0 && (pieces[bottomIncr - 1][column] == null || pieces[bottomIncr - 1][column].Team != Team))
        {
            bottomIncr--;
            moves.Add(new ChessSquare(bottomIncr + 1, currentSquare.Column));
            if (pieces[bottomIncr][column] != null)
            {
                break;
            }
        }

        while (rightIncr < 7 && (pieces[row][rightIncr + 1] == null || pieces[row][rightIncr + 1].Team != Team))
        {
            rightIncr++;
            moves.Add(new ChessSquare(currentSquare.Row, (char)(rightIncr + 65)));
            if (pieces[row][rightIncr] != null)
            {
                break;
            }
        }

        while (leftIncr > 0 && (pieces[row][leftIncr - 1] == null || pieces[row][leftIncr - 1].Team != Team))
        {
            leftIncr--;
            moves.Add(new ChessSquare(currentSquare.Row, (char)(leftIncr + 65)));
            if (pieces[row][leftIncr] != null)
            {
                break;
            }
        }

        if (element.HasValue && element.Value == elementalSquares[row][column])
        {
            switch (element.Value)
            {
                case 0:
                    for (var i = 0; i < pieces.Length; i++)
                    {
                        for (var j = 0; j < pieces[i].Length; j++)
                        {
                            var colDiff = column - j;
                            var rowDiff = row - i;

                            if (elementalSquares[i][j] == 0 && (pieces[i][j] == null || pieces[i][j].Team != Team) && (rowDiff == 0 || colDiff == 0))
                            {
                                moves.Add(new ChessSquare(i + 1, (char)(j + 65)));
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
}
