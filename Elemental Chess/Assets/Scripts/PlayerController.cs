using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerController
{

    private static int team1Element = -1;
    private static int team2Element = -1;

    public static void setTeam1Element(int elementId)
    {
        team1Element = elementId;
        Debug.Log(team1Element + "");
    }

    public static void setTeam2Element(int elementId)
    {
        team2Element = elementId;
        Debug.Log(team2Element + "");

    }

    public static int getTeam1Element()
    {
        return team1Element;
    }
    public static int getTeam2Element()
    {
        return team2Element;
    }
}
