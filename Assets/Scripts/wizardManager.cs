using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardManager : MonoBehaviour
{

    public static wizardManager instance;
    public GameObject wizard1;
    public GameObject wizard2;
    private wizardShopData wizardToBuild;
    public bool CanBuild { get { return wizardToBuild != null; } }
    private void Awake()
    {
        instance = this;
    }
    public void selectWizardToSpawn(wizardShopData wizard)
    {
        wizardToBuild = wizard;
    }
    public void placeWizardOn(tiles tile)
    {
        if (gameStats.coins < wizardToBuild.cost)
        {
            Debug.Log("YOU ARE BROKE");
            return;
        }

        gameStats.coins -= wizardToBuild.cost;

        GameObject wizardLocal = (GameObject)Instantiate(wizardToBuild.prefab, tile.transform.position + tile.positionOffset, tile.transform.rotation);
        tile.wizard = wizardLocal;
    }
}
