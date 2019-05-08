using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject Team1Pawn1;
    public GameObject Team1Pawn2;
    public GameObject Team1Pawn3;
    public GameObject Team1Pawn4;
    public GameObject Team1Pawn5;
    public GameObject Team1Pawn6;
    public GameObject Team1Pawn7;
    public GameObject Team1Pawn8;
    public GameObject Team1RookL;
    public GameObject Team1RookR;
    public GameObject Team1KnightL;
    public GameObject Team1KnightR;
    public GameObject Team1BishopL;
    public GameObject Team1BishopR;
    public GameObject Team1Queen;
    public GameObject Team1King;

    public GameObject Team2Pawn1;
    public GameObject Team2Pawn2;
    public GameObject Team2Pawn3;
    public GameObject Team2Pawn4;
    public GameObject Team2Pawn5;
    public GameObject Team2Pawn6;
    public GameObject Team2Pawn7;
    public GameObject Team2Pawn8;
    public GameObject Team2RookL;
    public GameObject Team2RookR;
    public GameObject Team2KnightL;
    public GameObject Team2KnightR;
    public GameObject Team2BishopL;
    public GameObject Team2BishopR;
    public GameObject Team2Queen;
    public GameObject Team2King;

    public Material FireElement;
    public Material WaterElement;
    public Material ShadowElement;
    public Material EarthElement;
    public Material AirElement;
    public Material WildcardElement;

    private List<GameObject> _team1Pieces;
    private List<GameObject> _team2Pieces;
    /*
     * A1 = -3, -3
     * A8 = 4, 4
     * H8 = 4, -3
     */

    // Start is called before the first frame update
    void Start()
    {
        InstantiatePieces();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiatePieces()
    {
        var bottomLeft = new Vector3(-3f, -0.05f, -3f);
        var pieceSize = new Vector3(50f, 50f, 50f);
        // Team 1
        var team1Pawn1 = Instantiate(Team1Pawn1);
        var team1Pawn2 = Instantiate(Team1Pawn2);
        var team1Pawn3 = Instantiate(Team1Pawn3);
        var team1Pawn4 = Instantiate(Team1Pawn4);
        var team1Pawn5 = Instantiate(Team1Pawn5);
        var team1Pawn6 = Instantiate(Team1Pawn6);
        var team1Pawn7 = Instantiate(Team1Pawn7);
        var team1Pawn8 = Instantiate(Team1Pawn8);
        var team1RookL = Instantiate(Team1RookL);
        var team1RookR = Instantiate(Team1RookR);
        var team1KnightL = Instantiate(Team1KnightL);
        var team1KnightR = Instantiate(Team1KnightR);
        var team1BishopL = Instantiate(Team1BishopL);
        var team1BishopR = Instantiate(Team1BishopR);
        var team1Queen = Instantiate(Team1Queen);
        var team1King = Instantiate(Team1King);
        _team1Pieces = new List<GameObject>
        {
            team1Pawn1,
            team1Pawn2,
            team1Pawn3,
            team1Pawn4,
            team1Pawn5,
            team1Pawn6,
            team1Pawn7,
            team1Pawn8,
            team1RookL,
            team1RookR,
            team1KnightL,
            team1KnightR,
            team1BishopL,
            team1BishopR,
            team1Queen,
            team1King
        };

        // Team 2
        var team2Pawn1 = Instantiate(Team2Pawn1);
        var team2Pawn2 = Instantiate(Team2Pawn2);
        var team2Pawn3 = Instantiate(Team2Pawn3);
        var team2Pawn4 = Instantiate(Team2Pawn4);
        var team2Pawn5 = Instantiate(Team2Pawn5);
        var team2Pawn6 = Instantiate(Team2Pawn6);
        var team2Pawn7 = Instantiate(Team2Pawn7);
        var team2Pawn8 = Instantiate(Team2Pawn8);
        var team2RookL = Instantiate(Team2RookL);
        var team2RookR = Instantiate(Team2RookR);
        var team2KnightL = Instantiate(Team2KnightL);
        var team2KnightR = Instantiate(Team2KnightR);
        var team2BishopL = Instantiate(Team2BishopL);
        var team2BishopR = Instantiate(Team2BishopR);
        var team2Queen = Instantiate(Team2Queen);
        var team2King = Instantiate(Team2King);
        _team2Pieces = new List<GameObject>
        {
            team2Pawn1,
            team2Pawn2,
            team2Pawn3,
            team2Pawn4,
            team2Pawn5,
            team2Pawn6,
            team2Pawn7,
            team2Pawn8,
            team2RookL,
            team2RookR,
            team2KnightL,
            team2KnightR,
            team2BishopL,
            team2BishopR,
            team2Queen,
            team2King
        };

        var allPieces = new List<GameObject>();
        allPieces.AddRange(_team1Pieces);
        allPieces.AddRange(_team2Pieces);

        foreach (var piece in allPieces)
        {
            piece.transform.SetParent(gameObject.transform);
        }

        var pawns = new List<GameObject[]>
        {
            new [] { team1Pawn1, team2Pawn1 },
            new [] { team1Pawn2, team2Pawn2 },
            new [] { team1Pawn3, team2Pawn3 },
            new [] { team1Pawn4, team2Pawn4 },
            new [] { team1Pawn5, team2Pawn5 },
            new [] { team1Pawn6, team2Pawn6 },
            new [] { team1Pawn7, team2Pawn7 },
            new [] { team1Pawn8, team2Pawn8 }
        };

        for (var i = 0; i < 8; i++)
        {
            var pawnRow1Vector = bottomLeft;
            pawnRow1Vector.z += 1;
            pawnRow1Vector.x += i;
            var pawnRow2Vector = bottomLeft;
            pawnRow2Vector.z += 6;
            pawnRow2Vector.x += i;
            pawns[i][0].transform.localPosition = pawnRow1Vector;
            pawns[i][0].transform.localScale = pieceSize;
            pawns[i][0].GetComponent<MeshRenderer>().material = WaterElement;
            pawns[i][1].transform.localPosition = pawnRow2Vector;
            pawns[i][1].transform.localScale = pieceSize;
            pawns[i][1].GetComponent<MeshRenderer>().material = ShadowElement;
            Debug.Log($"Pawn {i} at position x={pawns[i][0].transform.localPosition.x} y={pawns[i][0].transform.localPosition.y} z={pawns[i][0].transform.localPosition.z}");
        }
    }

    void RandomizeSquareElements()
    {
        //gameObject.child
    }
}
