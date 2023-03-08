using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiles : MonoBehaviour
{
    private GameObject wizard;
    public Vector3 positionOffset;

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        // if there is a wizard
        if (wizard != null)
        {
            Debug.Log("theres a wizard here man");
            return;
        }
        // place wizard
        GameObject wizardToBuild = wizardManager.instance.GetTurrentToBuild(1);
        wizard = (GameObject)Instantiate(wizardToBuild, transform.position + positionOffset, transform.rotation);
    }


    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
