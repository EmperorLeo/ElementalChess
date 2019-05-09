using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenPiece : BasePiece
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
        var moves = new List<ChessSquare>();
        var column = currentSquare.Column - 65;
        var row = currentSquare.Row - 1;

        // Handle rook-like moves
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


        // Handle bishop-like moves
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
        while (bottomRightRowIncr > 0 && bottomRightColIncr < 7 && (pieces[bottomRightRowIncr - 1][bottomRightColIncr - 1] == null || pieces[bottomRightRowIncr - 1][bottomRightColIncr - 1].Team != Team))
        {
            bottomRightRowIncr--;
            bottomRightColIncr++;
            moves.Add(new ChessSquare(bottomRightRowIncr + 1, (char)(bottomRightColIncr + 65)));
            if (pieces[bottomRightRowIncr][bottomRightColIncr] != null)
            {
                break;
            }
        }


        return moves;
    }
}
