using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tiles : MonoBehaviour
{
    public GameObject wizard;
    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    wizardManager wizardMngr;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        wizardMngr = wizardManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!wizardMngr.CanBuild)
        {
            return;
        }
        if (wizardMngr.hasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = Color.red;
        }
        
    }

    public void SellWizard()
    {
        Destroy(wizard);
    }

    private void OnMouseDown()
    {
        if (!wizardMngr.CanBuild)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        // if there is a wizard
        if (wizard != null)
        {
            Debug.Log("theres a wizard here man");
            return;
        }
        // place wizard
        wizardMngr.placeWizardOn(this);
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
