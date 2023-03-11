using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesManager : MonoBehaviour
{

    public static bool gameEnded = false;

    public GameObject gameoverUI;
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
        gameoverUI.SetActive(true);
    }
}
