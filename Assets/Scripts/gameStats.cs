using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStats : MonoBehaviour
{
    public static int coins;
    public int startingMoney = 20;
    private void Start()
    {
        coins = startingMoney;
    }

}
