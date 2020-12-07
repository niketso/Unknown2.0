using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : Interactable
{
    [SerializeField]
    public GameObject stopingZone;
    [SerializeField]
    GameObject otherObject = null;
    [HideInInspector]
    public Vector3 stopingZonePos;
    [SerializeField]
    public GameObject illuminatinController;

    PlayerAnimator playerAnimator;


    [SerializeField]   
    PopUpController popUpController = null;    
    string playerSays = "The power is back!";

    public bool canUse = false;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
        playerAnimator = player.GetComponent<PlayerAnimator>();        
    }

    public override void Interact()
    {
        base.Interact();
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
        illuminatinController.GetComponent<illuminationController>().ChangeLights();
        Invoke("EnableMouse", 0.5f);
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

    void EnableMouse()
    {
        InputManager.instance.UnlockMouse();
        playerAnimator.Idle();
    }

}
