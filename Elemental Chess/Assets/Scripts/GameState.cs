using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    #region GameObjects
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
    public Material BorderMaterial;
    public Material SelectedBorderMaterial;
    #endregion

    private List<GameObject> _team1GameObjects;
    private List<GameObject> _team2GameObjects;
    private List<BasePiece> _team1Pieces;
    private List<BasePiece> _team2Pieces;
    private int turn;
    private float gameTime;
    private int[][] cellElements;
    private BasePiece[][] piecePositions;
    //private int[][] teamPositions;
    private Material[][] squareMaterials;
    private int team1Element;
    private int team2Element;
    private Color[] startingColors;
    private Color[] targetColors;
    private Material[] materials;
    private GameObject selectedPiece;
    private IEnumerable<ChessSquare> availableMoves;

    /*
     * A1 = -3, -3
     * A8 = 4, 4
     * H8 = 4, -3
     */
    
    void Awake()
    {
        team1Element = 3;
        team2Element = 4;
    }

    // Start is called before the first frame update
    void Start()
    {
        materials = new Material[] { AirElement, EarthElement, FireElement, ShadowElement, WaterElement, WildcardElement };
        InstantiatePieces();
        RandomizeSquareElements();
        SwitchTurns();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        UpdateChargingAnimation();
    }

    private void InstantiatePieces()
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
        _team1GameObjects = new List<GameObject>
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
        _team1Pieces = _team1GameObjects.Select(x => x.GetComponent<BasePiece>()).ToList();

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
        _team2GameObjects = new List<GameObject>
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
        _team2Pieces = _team2GameObjects.Select(x => x.GetComponent<BasePiece>()).ToList();

        var allPieces = new List<GameObject>();
        allPieces.AddRange(_team1GameObjects);
        allPieces.AddRange(_team2GameObjects);

        foreach (var piece in allPieces)
        {
            piece.transform.SetParent(gameObject.transform);
        }
        foreach (var piece in _team1GameObjects)
        {
            piece.GetComponent<BasePiece>().Team = 1;
        }
        foreach (var piece in _team2GameObjects)
        {
            piece.GetComponent<BasePiece>().Team = 2;
        }

        var columnPieces = new List<GameObject[]>
        {
            new [] { team1Pawn1, team2Pawn1, team1RookL, team2RookL },
            new [] { team1Pawn2, team2Pawn2, team1KnightL, team2KnightL },
            new [] { team1Pawn3, team2Pawn3, team1BishopL, team2BishopL },
            new [] { team1Pawn4, team2Pawn4, team1Queen, team2Queen },
            new [] { team1Pawn5, team2Pawn5, team1King, team2King },
            new [] { team1Pawn6, team2Pawn6, team1BishopR, team2BishopR },
            new [] { team1Pawn7, team2Pawn7, team1KnightR, team2KnightR },
            new [] { team1Pawn8, team2Pawn8, team1RookR, team2RookR }
        };

        piecePositions = new BasePiece[][] {
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8],
            new BasePiece[8]
        };
        //teamPositions = new int[][]
        //{
        //    new int[8],
        //    new int[8],
        //    new int[8],
        //    new int[8],
        //    new int[8],
        //    new int[8],
        //    new int[8],
        //    new int[8]
        //};

        for (var i = 0; i < 8; i++)
        {
            var letter = (char)(i + 65);
            var pawnRow1Vector = bottomLeft;
            pawnRow1Vector.z += 1;
            pawnRow1Vector.x += i;
            var pawnRow2Vector = bottomLeft;
            pawnRow2Vector.z += 6;
            pawnRow2Vector.x += i;
            var otherRow1Vector = bottomLeft;
            otherRow1Vector.x += i;
            var otherRow2Vector = bottomLeft;
            otherRow2Vector.z += 7;
            otherRow2Vector.x += i;

            columnPieces[i][0].transform.localPosition = pawnRow1Vector;
            columnPieces[i][0].transform.localScale = pieceSize;
            columnPieces[i][0].GetComponent<MeshRenderer>().material = materials[team1Element];
            columnPieces[i][0].GetComponent<BasePiece>().StartAt(new ChessSquare(2, letter), piecePositions);
            piecePositions[1][i] = columnPieces[i][0].GetComponent<BasePiece>();
            //teamPositions[1][i] = 1;
            columnPieces[i][2].transform.localPosition = otherRow1Vector;
            columnPieces[i][2].transform.localScale = pieceSize;
            columnPieces[i][2].GetComponent<MeshRenderer>().material = materials[team1Element];
            columnPieces[i][2].GetComponent<BasePiece>().StartAt(new ChessSquare(1, letter), piecePositions);
            piecePositions[0][i] = columnPieces[i][2].GetComponent<BasePiece>();
            //teamPositions[0][i] = 1;
            columnPieces[i][1].transform.localPosition = pawnRow2Vector;
            columnPieces[i][1].transform.localScale = pieceSize;
            columnPieces[i][1].GetComponent<MeshRenderer>().material = materials[team2Element];
            columnPieces[i][1].GetComponent<BasePiece>().StartAt(new ChessSquare(7, letter), piecePositions);
            piecePositions[6][i] = columnPieces[i][1].GetComponent<BasePiece>();
            //teamPositions[6][i] = 2;
            columnPieces[i][3].transform.localPosition = otherRow2Vector;
            columnPieces[i][3].transform.localScale = pieceSize;
            columnPieces[i][3].GetComponent<MeshRenderer>().material = materials[team2Element];
            columnPieces[i][3].GetComponent<BasePiece>().StartAt(new ChessSquare(8, letter), piecePositions);
            piecePositions[7][i] = columnPieces[i][3].GetComponent<BasePiece>();
            //teamPositions[7][i] = 2;
        }
    }

    private void RandomizeSquareElements()
    {
        cellElements = new int[][] {
            new int[8],
            new int[8],
            new int[8],
            new int[8],
            new int[8],
            new int[8],
            new int[8],
            new int[8]
        };

        startingColors = new Color[] { new Color32(216, 217, 215, 255), new Color32(130, 19, 19, 255), new Color32(217, 38, 38, 255), new Color32(72, 21, 77, 255), new Color32(76, 123, 214, 255), new Color32(0, 0, 0, 255) };
        targetColors = new Color[] { new Color32(231, 232, 230, 150), new Color32(145, 34, 34, 150), new Color32(232, 53, 53, 150), new Color32(135, 60, 143, 150), new Color32(91, 238, 229, 150), new Color32(0, 0, 0, 150) };
        squareMaterials = new Material[][]
        {
            new Material[8],
            new Material[8],
            new Material[8],
            new Material[8],
            new Material[8],
            new Material[8],
            new Material[8],
            new Material[8]
        };
        var row = 0;
        var column = 0;
        foreach (var chessRow in gameObject.transform)
        {
            foreach (var square in (Transform)chessRow)
            {
                var chessSquare = (Transform)square;
                var materialIndex = Random.Range(0, materials.Length - 1);
                var material = chessSquare.GetComponent<Renderer>().material;
                material.color = startingColors[materialIndex];
                squareMaterials[7 - row][7 - column] = material;
                cellElements[7 - row][7 - column] = materialIndex;
                column++;
            }
            row++;
            column = 0;
        }
    }

    private void TakeTurn()
    {
        if (turn == 1)
        {
            turn = 2;
        }
        else
        {
            turn = 1;
        }
    }

    private void UpdateChargingAnimation()
    {
        for (var i = 0; i < cellElements.Length; i++)
        {
            for (var j = 0; j < cellElements.Length; j++)
            {
                var squareElement = cellElements[i][j];
                if (piecePositions[i][j] != null)
                {
                    var team = piecePositions[i][j].Team;
                    int teamElement;
                    if (team == 1)
                    {
                        teamElement = team1Element;
                    }
                    else
                    {
                        teamElement = team2Element;
                    }

                    if (squareElement == teamElement)
                    {
                        var material = squareMaterials[i][j];
                        var targetColor = targetColors[squareElement];
                        var startingColor = startingColors[squareElement];

                        const int oscillationtime = 2;

                        Color newColor;
                        var darker = Mathf.FloorToInt(gameTime) % (oscillationtime * 2) >= oscillationtime;
                        var t = (gameTime - (Mathf.FloorToInt(gameTime / oscillationtime) * oscillationtime)) / oscillationtime;
                        if (darker)
                        {
                            newColor = Color.Lerp(targetColor, startingColor, t);
                        }
                        else
                        {
                            newColor = Color.Lerp(startingColor, targetColor, t);
                        }
                        material.color = newColor;
                    }
                }
            }
        }
    }

    private void SwitchTurns()
    {
        turn = (turn % 2) + 1;
        _team1GameObjects.ForEach(x => x.GetComponent<BasePiece>().Selectable = turn == 1);
        _team2GameObjects.ForEach(x => x.GetComponent<BasePiece>().Selectable = turn == 2);
    }

    private void HighlightSquare(ChessSquare square, bool selecting)
    {
        Material chosenMaterial;
        if (selecting)
        {
            chosenMaterial = Instantiate(SelectedBorderMaterial);
        }
        else
        {
            chosenMaterial = Instantiate(BorderMaterial);
        }
        var path = $"StandardChessRow{square.Row}/Cube{square.Column}";
        var component = gameObject.transform.Find(path);
        foreach (var border in component)
        {
            var borderTransform = (Transform)border;
            borderTransform.gameObject.GetComponent<Renderer>().material = chosenMaterial;
        }

        if (square.Row < 8)
        {
            var northBorder = gameObject.transform.Find($"StandardChessRow{square.Row + 1}/Cube{square.Column}/BorderS");
            var borderTransform = (Transform)northBorder;
            borderTransform.gameObject.GetComponent<Renderer>().material = chosenMaterial;
        }

        if (square.Row > 0)
        {
            var southBorder = gameObject.transform.Find($"StandardChessRow{square.Row - 1}/Cube{square.Column}/BorderN");
            var borderTransform = (Transform)southBorder;
            borderTransform.gameObject.GetComponent<Renderer>().material = chosenMaterial;
        }

        if (square.Column != 'A')
        {
            var westBorder = gameObject.transform.Find($"StandardChessRow{square.Row}/Cube{(char)(square.Column - 1)}/BorderE");
            var borderTransform = (Transform)westBorder;
            borderTransform.gameObject.GetComponent<Renderer>().material = chosenMaterial;
        }

        if (square.Column != 'H')
        {
            var eastBorder = gameObject.transform.Find($"StandardChessRow{square.Row}/Cube{(char)(square.Column + 1)}/BorderW");
            var borderTransform = (Transform)eastBorder;
            borderTransform.gameObject.GetComponent<Renderer>().material = chosenMaterial;
        }
    }

    void SelectPiece(BasePiece piece)
    {
        _team1Pieces.ForEach(x => x.Selectable = false);
        _team2Pieces.ForEach(x => x.Selectable = false);
        piece.Selectable = true;
        availableMoves = piece.GetAvailableMoves(piecePositions);
        foreach (var move in availableMoves)
        {
            Debug.Log(move.ToString());
            HighlightSquare(move, true);
        }
    }

    void DeselectPiece(BasePiece piece)
    {
        _team1Pieces.ForEach(x => x.Selectable = turn == 1);
        _team2Pieces.ForEach(x => x.Selectable = turn == 2);
        foreach (var move in availableMoves)
        {
            HighlightSquare(move, false);
        }
        availableMoves = Enumerable.Empty<ChessSquare>();
    }
}
