using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tiles : MonoBehaviour
{
    private GameObject wizard;
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
        if (wizardMngr.GetTurrentToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (wizardMngr.GetTurrentToBuild() == null)
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
        GameObject wizardToBuild = wizardMngr.GetTurrentToBuild();
        wizard = (GameObject)Instantiate(wizardToBuild, transform.position + positionOffset, transform.rotation);
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
