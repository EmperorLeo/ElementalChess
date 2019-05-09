using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePiece : MonoBehaviour
{
    public int Team;
    public int Element;
    public bool Selectable;

    protected ChessSquare currentSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var selected = gameObject.GetComponent<PieceController>().IsSelected();
    }

    public abstract IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces);

    public void StartAt(ChessSquare square, BasePiece[][] pieces)
    {
        pieces[square.Row - 1][square.Column - 65] = this;
        currentSquare = square;
    }

    public virtual string MoveTo(ChessSquare square, BasePiece[][] pieces)
    {
        var opposingPiece = pieces[square.Row - 1][square.Column - 65];
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
        pieces[square.Row - 1][square.Column - 65] = this;
        if (currentSquare != null)
        {
            pieces[currentSquare.Row - 1][currentSquare.Column - 65] = null;
        }
        currentSquare = square;

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
