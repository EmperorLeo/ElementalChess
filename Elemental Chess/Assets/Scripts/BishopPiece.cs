using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopPiece : BasePiece
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

        var topLeftRowIncr = row;
        var topLeftColIncr = column;
        while (topLeftRowIncr < 7 && topLeftColIncr > 0 && (pieces[topLeftRowIncr + 1][topLeftColIncr - 1] == null || pieces[topLeftRowIncr + 1][topLeftColIncr - 1].Team != Team))
        {
            topLeftRowIncr++;
            topLeftColIncr--;
            moves.Add(new ChessSquare(topLeftRowIncr + 1, (char)(topLeftColIncr + 65)));
            if (pieces[topLeftRowIncr][topLeftColIncr] != null)
            {
                break;
            }
        }

        var topRightRowIncr = row;
        var topRightColIncr = column;
        while (topRightRowIncr < 7 && topRightColIncr < 7 && (pieces[topRightRowIncr + 1][topRightColIncr + 1] == null || pieces[topRightRowIncr + 1][topRightColIncr + 1].Team != Team))
        {
            topRightRowIncr++;
            topRightColIncr++;
            moves.Add(new ChessSquare(topRightRowIncr + 1, (char)(topRightColIncr + 65)));
            if (pieces[topRightRowIncr][topRightColIncr] != null)
            {
                break;
            }
        }

        var bottomLeftRowIncr = row;
        var bottomLeftColIncr = column;
        while (bottomLeftRowIncr > 0 && bottomLeftColIncr > 0 && (pieces[bottomLeftRowIncr - 1][bottomLeftColIncr - 1] == null || pieces[bottomLeftRowIncr - 1][bottomLeftColIncr - 1].Team != Team))
        {
            bottomLeftRowIncr--;
            bottomLeftColIncr--;
            moves.Add(new ChessSquare(bottomLeftRowIncr + 1, (char)(bottomLeftColIncr + 65)));
            if (pieces[bottomLeftRowIncr][bottomLeftColIncr] != null)
            {
                break;
            }
        }

        var bottomRightRowIncr = row;
        var bottomRightColIncr = column;
        while (bottomRightRowIncr > 0 && bottomRightColIncr < 7 && (pieces[bottomRightRowIncr - 1][bottomRightColIncr + 1] == null || pieces[bottomRightRowIncr - 1][bottomRightColIncr + 1].Team != Team))
        {
            bottomRightRowIncr--;
            bottomRightColIncr++;
            moves.Add(new ChessSquare(bottomRightRowIncr + 1, (char)(bottomRightColIncr + 65)));
            if (pieces[bottomRightRowIncr][bottomRightColIncr] != null)
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
                            var colDiff = Math.Abs(column - j);
                            var rowDiff = Math.Abs(row - i);

                            if (elementalSquares[i][j] == 0 && (pieces[i][j] == null || pieces[i][j].Team != Team) && rowDiff == colDiff)
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
