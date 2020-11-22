using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ItemOpen : Interactable
{
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
    public string  playerSays2 = "It's Locked!";

    private void Start()
    {
        stoppingZonePos = stoppingZone.transform.position;
        if(isLocked)
        destinationLockedDoorPos = new Vector3(destinationLockedDoor.transform.position.x, destinationLockedDoor.transform.position.y, destinationLockedDoor.transform.position.z);
    }
    public override void Interact()
    {
        base.Interact();
        //Open();
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
            Invoke("moveToPosition", 2);
        }        
    }

    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }

    void moveToPosition()
    {
        Debug.Log("MOVE TO POSITION >> " + player.GetComponent<NavMeshAgent>().destination);
        //player.GetComponent<NavMeshAgent>().destination = destinationLockedDoorPos;
        player.GetComponent<PlayerMovement>().Walk(destinationLockedDoorPos);
    }


}
