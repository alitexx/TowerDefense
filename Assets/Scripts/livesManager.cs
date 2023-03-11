using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesManager : MonoBehaviour
{

    private bool gameEnded = false;
    private void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (gameStats.Lives <= 0)
        {
            endGame();
        }
    }
    private void endGame()
    {
        gameEnded = true;
        Debug.Log("END GAME");
    }
}
