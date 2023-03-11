using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    void Update()
    {
        moneyText.text = "$" + gameStats.coins.ToString();
    }
}
