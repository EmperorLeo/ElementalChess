using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePiece : MonoBehaviour
{
    public int Team;
    public int Element;
    public bool Selectable;
    public bool Dead;

    private Material material;
    private Color color;

    protected ChessSquare currentSquare;

    public abstract IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces, int? element, int[][] elementalSquares);

    public void StartAt(ChessSquare square, BasePiece[][] pieces)
    {
        pieces[square.Row - 1][square.Column - 65] = this;
        currentSquare = square;
        var rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
        rigidBody.detectCollisions = false;
        material = GetComponent<Renderer>().material;
        color = material.color;
    }

    public virtual string MoveTo(ChessSquare square, BasePiece[][] pieces, bool isBuffed)
    {
        var opposingPiece = pieces[square.Row - 1][square.Column - 65];

        if (isBuffed)
        {
            if (Element == 2) // Fire
            {
                var burnoutPieces = StraightLineWalk(square, pieces);
                foreach (var piece in burnoutPieces)
                {
                    var burnoutRigidBody = piece.GetComponent<Rigidbody>();
                    burnoutRigidBody.isKinematic = false;
                    burnoutRigidBody.detectCollisions = true;
                    piece.Dead = true;
                }
            }
        }

        Rigidbody rb;
        Rigidbody currentrb;
        var capturing = false;
        var check = IsCheck(pieces);
        var checkmate = false;
        if (opposingPiece != null)
        {
            capturing = true;
            rb = opposingPiece.GetComponent<Rigidbody>();
            currentrb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.detectCollisions = true;
            currentrb.isKinematic = false;
            currentrb.detectCollisions = true;

            //KillPiece(rb);
            //if (isBuffed)
            //{
            //    if (Element == 2)    
            //        KillPiece(currentrb);
            //    else if (Element == 4)                                  
            //    KillPiece(currentrb);
            //    else
            //      KillPiece(rb);
                
            //      KillPiece(currentrb);
            //}
            opposingPiece.Dead = true;
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

    public void KillPiece(Rigidbody rb)
    {
        rb.AddForce(rb.transform.up * 20, ForceMode.Impulse);
    }

    public bool CheckElement(int[][] cellElements)
    {
        var cellElementMaterialIndex = cellElements[currentSquare.Row - 1][currentSquare.Column - 65];

        return cellElementMaterialIndex == Element;
    }

    public void Select()
    {
        color.a = 0.5f;
        GetComponent<Renderer>().material.color = color;
    }

    public void Deselect()
    {
        color.a = 1;
        GetComponent<Renderer>().material.color = color;
    }

    private List<BasePiece> StraightLineWalk(ChessSquare target, BasePiece[][] pieces)
    {
        var inPath = new List<BasePiece>();
        var colDiff = target.Column - currentSquare.Column;
        var colSign = colDiff > 0 ? 1 : -1;
        var rowDiff = target.Row - currentSquare.Row;
        var rowSign = rowDiff > 0 ? 1 : -1;

        var row = currentSquare.Row - 1;
        var col = currentSquare.Column - 65;

        if (colDiff == 0)
        {
            for (var i = 1; i < Math.Abs(rowDiff); i++)
            {
                var possibleTarget = pieces[row + (i * rowSign)][col];
                if (possibleTarget != null && possibleTarget.Team != Team)
                {
                    inPath.Add(possibleTarget);
                }
            }
        }
        else if (rowDiff == 0)
        {
            for (var i = 1; i < Math.Abs(colDiff); i++)
            {
                var possibleTarget = pieces[row][col + (i * colSign)];
                if (possibleTarget != null && possibleTarget.Team != Team)
                {
                    inPath.Add(possibleTarget);
                }
            }
        }
        else if (Math.Abs(rowDiff) == Math.Abs(colDiff))
        {
            for (var i = 1; i < Math.Abs(colDiff); i++)
            {
                var possibleTarget = pieces[row + (i * rowSign)][col + (i * colSign)];
                if (possibleTarget != null && possibleTarget.Team != Team)
                {
                    inPath.Add(possibleTarget);
                }
            }
        }

        return inPath;
    }
}

public class ChessSquare
{
    public int Row { get; }
    public char Column { get; }
    public bool Special { get; }

    public ChessSquare(int row, char column)
    {
        Column = column;
        Row = row;
    }

    public ChessSquare(int row, char column, bool special) : this(row, column)
    {
        Special = special;
    }

    public override string ToString()
    {
        return $"{Column}{Row}".ToLower();
    }
}
