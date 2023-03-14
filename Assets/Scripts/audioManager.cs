using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioSource levelBGM;


    private void Start()
    {
        startGame();
    }
    public void startGame()
    {
        levelBGM.Play();
    }
}
