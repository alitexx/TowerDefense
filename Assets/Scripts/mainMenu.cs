using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("actualGame");
    }
    public void quit() 
    {
        Application.Quit();
    }
}
