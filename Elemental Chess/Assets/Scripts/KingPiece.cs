using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPiece : BasePiece
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Dead)
        {
            SendMessageUpwards("GameOverMan", Team);
        }
    }

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces, int? element, int[][] elementalSquares)
    {
        var moves = new List<ChessSquare>();
        var row = currentSquare.Row - 1;
        var column = currentSquare.Column - 65;

        for (var r = -1; r < 2; r++)
        {
            for (var c = -1; c < 2; c++)
            {
                if (c != 0 || r != 0)
                {
                    if (row + r < 0 || row + r > 7 || column + c < 0 || column + c > 7 || (pieces[row + r][column + c] != null && pieces[row + r][column + c].Team == Team))
                    {
                        continue;
                    }

                    moves.Add(new ChessSquare(row + r + 1, (char)(column + c + 65)));
                }
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
                            if (elementalSquares[i][j] == 0 && (pieces[i][j] == null || pieces[i][j].Team != Team))
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
