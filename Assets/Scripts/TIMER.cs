using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TIMER : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timer;
    public GameObject winScreen;
    public GameObject pauseMenu;
    public float gameTimer = 60;

    // Update is called once per frame
    void Update()
    {

        if (gameTimer > 0 && !pauseMenu.activeSelf)
        {
            gameTimer -= Time.deltaTime;
            _timer.text = ((int)(gameTimer)).ToString();

        }
        else if (gameTimer < 0) // if timer hits 0, player loses
        {
            winScreen.SetActive(true);
        }
    }
}
