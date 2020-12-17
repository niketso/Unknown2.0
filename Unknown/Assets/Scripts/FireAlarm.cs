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

    private PlayerAnimator playerAnimator;

    string playerSays = "There's no power!";
    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
        playerAnimator = player.GetComponent<PlayerAnimator>();
    }
    public override void Interact()
    {
        base.Interact();
    }

    public void Activate()
    {        
        if (isUsable == true)
        {
            sprinklers.SetActive(true);
            AudioManager.instance.Play("FireAlarm",false);
            AudioManager.instance.Play("FireOff", false);
            Invoke("destroyFire", 3);
            Invoke("enableMouse", 3);
            Invoke("disableSprinklers",6);
            playerAnimator.Idle();
        }
        else
        {
            AudioManager.instance.Play("AlarmBreaker", false);
            popUpController.PlayerWindow(playerSays);                      
            Invoke("disablePopUp", 3);
            Invoke("enableMouse", 3);
            playerAnimator.Idle();
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
        AudioManager.instance.StopSound("Fire1");
        Destroy(fire);
    }
    void enableMouse()
    {
        InputManager.instance.UnlockMouse();
    }
}
