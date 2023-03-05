using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placeTower : MonoBehaviour
{
    GameObject activateBuyingGUI;
    GameObject closeBuyingWindowGUI;
    private bool endPurchase = true;
    public void buyWizard(int wizardNum)
    {
        Debug.Log("I have clicked a silly button");
        endPurchase = false;
        //wizardnum is what wizard we are spawning (used for spawning in wizard)
        // turn on GUI that explains what to do. turn off wizard button and replace it with another button to cancel
        //switch (wizardNum)
        //{
        //    case 1:
        //        activateBuyingGUI = GameObject.FindGameObjectWithTag("WizardSpawnButton1");
        //        break;
        //    case 2:
        //        activateBuyingGUI = GameObject.FindGameObjectWithTag("WizardSpawnButton2");
        //        break;
        //}

        //activateBuyingGUI.SetActive(false);
        //closeBuyingWindowGUI.SetActive(true);

        // begin raycasting to look for an open space.
        while (endPurchase != true)
        {
            Debug.Log("This is working");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.tag == "Tile")
            {
                hit.transform.Rotate(0, 0, 180.0f);
            }
        }


        

        // if ray hits a plane, flip that plane. save that plane here. turn the prior plane when it moves to another obj
        // if player clicks said plane, take their money away, and place one of the wizard prefab objects on that plane
    }
}
