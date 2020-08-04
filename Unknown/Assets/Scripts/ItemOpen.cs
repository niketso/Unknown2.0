using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOpen : Interactable
{
    [SerializeField]
    public bool isLocked;
    [SerializeField] GameObject stoppingZone;
    public Vector3 stoppingZonePos;
    [SerializeField]
    PopUpController popUpController;
    string playerSays1 = "It's Opened!";
    string playerSays2 = "It's Locked!";

    private void Start()
    {
        stoppingZonePos = stoppingZone.transform.position;
    }
    public override void Interact()
    {
        base.Interact();
        Open();
    }

    public void Open()
    {
        Debug.Log("OPEN");
        if (isLocked == false)
        {
            //popUpController.PlayerWindow(playerSays1);
            //Invoke("disablePopUp", 3);
            this.GetComponentInParent<Animator>().SetTrigger("OpenDoor");
            AudioManager.instance.Play("DoorOpen", false);
        }
        else
        {
            AudioManager.instance.Play("DoorLocked", false);
            popUpController.PlayerWindow(playerSays2);
            Invoke("disablePopUp", 3);
        }        
    }

    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }
}
