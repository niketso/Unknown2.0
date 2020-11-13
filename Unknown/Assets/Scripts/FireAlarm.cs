using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FireAlarm : Interactable
{
    public bool isUsable = false;
    [SerializeField]
    GameObject fire = null;
    [SerializeField]
    GameObject stopingZone = null;
    [HideInInspector]
    public Vector3 stopingZonePos;
    [SerializeField]
    GameObject sprinklers = null;

    [SerializeField] 
    PopUpController popUpController = null;

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
        if (isUsable == true)
        {
            sprinklers.SetActive(true);
            AudioManager.instance.Play("FireAlarm",false);
            AudioManager.instance.Play("FireOff", false);
            Invoke("destroyFire", 2);
            Invoke("disableSprinklers",6);
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
        AudioManager.instance.StopSound("FireAlarm");
    }

    void destroyFire()
    {
        Destroy(fire);
    }
}
