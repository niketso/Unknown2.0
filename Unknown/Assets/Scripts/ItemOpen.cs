﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ItemOpen : Interactable
{
    public PlayerAnimator playerAnimator;

    [SerializeField]
    public bool isLocked;

    [SerializeField]
    GameObject stoppingZone = null;    

    [SerializeField]
    PopUpController popUpController = null;

    [SerializeField]
    public GameObject destinationLockedDoor;

    [HideInInspector]
    public Vector3 stoppingZonePos;

    [HideInInspector]
    public Vector3 destinationLockedDoorPos;

    public string playerSays1 = "It's Opened!";
    public string playerSays2 = "It's Locked!";

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimator>();
        stoppingZonePos = stoppingZone.transform.position;
        if (isLocked)
        {
            destinationLockedDoorPos = new Vector3(destinationLockedDoor.transform.position.x, destinationLockedDoor.transform.position.y, destinationLockedDoor.transform.position.z);
        }
    }
    public override void Interact()
    {
        base.Interact();
    }

    public void Open()
    {
        if (isLocked == false)
        {
            this.GetComponentInParent<Animator>().SetTrigger("OpenDoor");
            AudioManager.instance.Play("DoorOpen", false);
            this.GetComponent<BoxCollider>().enabled = false;
            Invoke("enableMouse",2);
            playerAnimator.Idle();
        }
        else
        {
            AudioManager.instance.Play("DoorLocked", false);
            popUpController.PlayerWindow(playerSays2);
            Invoke("disablePopUp", 3);
            playerAnimator.Idle();
            Invoke("moveToPosition", 2);
        }        
    }

    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }

    void moveToPosition()
    {        
        player.GetComponent<PlayerMovement>().Walk(destinationLockedDoorPos);        
        Invoke("enableMouse", 3);
    }

    void enableMouse()
    {
        InputManager.instance.UnlockMouse();
    }
}
