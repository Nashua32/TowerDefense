using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private bool gameOn = true;
    void Update()
    {
        if (!gameOn)
        {
            return;
        }
        if(PlayerStats.lives <=0)
        {
            endGame();
        }
    }

    void endGame()
    {
        gameOn = false;
        Debug.Log("Game over!");
    }
}
