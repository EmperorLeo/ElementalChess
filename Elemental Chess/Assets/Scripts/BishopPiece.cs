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

    public override IEnumerable<ChessSquare> GetAvailableMoves(BasePiece[][] pieces)
    {
        var moves = new List<ChessSquare>();
        return moves;
    }
}
