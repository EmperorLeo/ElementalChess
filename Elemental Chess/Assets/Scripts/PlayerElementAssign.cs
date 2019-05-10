using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementAssign : MonoBehaviour
{
    public void setPlayer1Element(int id)
    {
        PlayerController.setTeam1Element(id);
    }

    public void setPlayer2Element(int id)
    {
        PlayerController.setTeam2Element(id);
    }
}
