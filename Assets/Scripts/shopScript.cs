using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour
{
    wizardManager wizardMngr;

    private void Start()
    {
        wizardMngr = wizardManager.instance;
    }
    public void PurchaseWizard1()
    {
        wizardMngr.SetWizardToSpawn(wizardMngr.wizard1);
    }

    public void PurchaseWizard2()
    {
        wizardMngr.SetWizardToSpawn(wizardMngr.wizard2);
    }
}
