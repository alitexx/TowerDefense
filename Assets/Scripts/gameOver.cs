using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("actualGame");
    }
    public void Menu()
    {
        Debug.Log("Go to menu");
    }
}
