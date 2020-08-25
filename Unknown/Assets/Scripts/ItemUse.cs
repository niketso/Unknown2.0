using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : Interactable
{
    [SerializeField]
    GameObject stopingZone;
    [SerializeField]
    GameObject otherObject;
    [HideInInspector]
    public Vector3 stopingZonePos;


    [SerializeField]   
    PopUpController popUpController;    
    string playerSays = "The power is back!";

    public bool canUse = false;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;        
    }

    public override void Interact()
    {
        base.Interact();
        Use();
    }

    public void Use()
    {
        Debug.Log("USE");
        //sonidos
        AudioManager.instance.Play("SwitchFlip",false);
        AudioManager.instance.Play("PowerOn", false);
        //habilitar alarma
        otherObject.GetComponent<FireAlarm>().isUsable = true;
        //texto
        popUpController.PlayerWindow(playerSays);
        Invoke("disablePopUp", 3);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = true;
        }
    }

    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }

}
