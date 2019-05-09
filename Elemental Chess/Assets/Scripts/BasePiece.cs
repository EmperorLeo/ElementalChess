using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePiece : MonoBehaviour
{
    public int Team;
    public int Element;

    protected ChessSquare currentSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces);

    public virtual string MoveTo(ChessSquare square, BasePiece[][] pieces)
    {
        currentSquare = square;
        var opposingPiece = pieces[square.Row][square.Column - 65];
        var capturing = false;
        var check = IsCheck(pieces);
        var checkmate = false;
        if (opposingPiece != null)
        {
            capturing = true;
        }
        if (check)
        {
            check = true;
            checkmate = IsCheckmate(pieces);
        }
        pieces[square.Row][square.Column - 65] = this;

        return $"{(capturing ? "x" : "")}{currentSquare.ToString()}{(check ? "+" : "")}{(checkmate ? "+": "")}";
    }

    private bool IsCheck(BasePiece[][] pieces)
    {
        return false;
    }

    private bool IsCheckmate(BasePiece[][] pieces)
    {
        return false;
    }
}

public class ChessSquare
{
    public int Row { get; }
    public char Column { get; }

    public ChessSquare(int row, char column)
    {
        Column = column;
        Row = row;
    }

    public override string ToString()
    {
        return $"{Column}{Row}".ToLower();
    }
}
