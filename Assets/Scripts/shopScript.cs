using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour
{
    public wizardShopData wizard1_Data;
    public wizardShopData wizard2_Data;

    wizardManager wizardMngr;

    private void Start()
    {
        wizardMngr = wizardManager.instance;
    }
    public void selectWizard1()
    {
        wizardMngr.selectWizardToSpawn(wizard1_Data);
    }

    public void selectWizard2()
    {
        wizardMngr.selectWizardToSpawn(wizard2_Data);
    }
}
