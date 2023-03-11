using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class livesUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Update()
    {
        text.text = gameStats.Lives.ToString();
    }
}
