using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FireAlarm : Interactable
{
    public bool isUsable = false;
    [SerializeField]
    GameObject fire;
    [SerializeField]
    GameObject stopingZone;
    [HideInInspector]
    public Vector3 stopingZonePos;
    [SerializeField]
    GameObject sprinklers;

    [SerializeField] 
    PopUpController popUpController;

    string playerSays = "There's no power!";
    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
    }
    public override void Interact()
    {
        base.Interact();

        Activate();
    }

    public void Activate()
    {
        Debug.Log("Use fire alarm");
        if (isUsable == true)
        {
            sprinklers.SetActive(true);
            Invoke("destroyFire", 2);
            Invoke("disableSprinklers",4);
        }
        else
        {
            popUpController.PlayerWindow(playerSays);                      
            Invoke("disablePopUp", 3);
        }
    }
    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }

    void disableSprinklers()
    {
        sprinklers.SetActive(false);
    }

    void destroyFire()
    {
        Destroy(fire);
    }
}
