using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardManager : MonoBehaviour
{

    public static wizardManager instance;
    public GameObject wizard1;
    public GameObject wizard2;
    private GameObject wizardToBuild;
    public GameObject GetTurrentToBuild(int wizardNum)
    {
        // for right now just return 1;

        return wizardToBuild;
    }
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Debug.Log(wizard1);
        wizardToBuild = wizard1;
    }
}
