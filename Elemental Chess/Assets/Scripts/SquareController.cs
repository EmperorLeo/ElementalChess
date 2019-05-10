using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    private char letter;
    private int column;

    // Start is called before the first frame update
    void Start()
    {
        letter = gameObject.name[4];
        column = int.Parse(gameObject.transform.parent.name.Replace("StandardChessRow", ""));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, 100.0f))
            {
                if (hit.transform != null && hit.transform.gameObject == gameObject)
                {
                    SendMessageUpwards("SquareClicked", this);
                }
            }
        }

    }

    public ChessSquare GetSquare()
    {
        return new ChessSquare(column, letter);
    }
}
