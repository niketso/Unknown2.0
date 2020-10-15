using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;
    [SerializeField] private PlayerController playerController = null;
    public bool pickingUp;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        Idle();
    }
    void Update()
    {
        pickingUp = playerAnimator.GetBool("PickingUp");

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick Up Front") || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open Door"))
        {
            playerAnimator.SetBool("PickingUp", true);
        }
        else
        {
            playerAnimator.SetBool("PickingUp", false);
        }
    }
    public void Idle()
    {
        if (!pickingUp)
        {
            playerAnimator.SetBool("Moving", false);
            playerAnimator.SetBool("Idle", true);
            playerAnimator.SetTrigger("Idle");
        }
    }
    public void Walk()
    {
        playerAnimator.SetBool("Idle", false);
        playerAnimator.SetBool("Moving", true);
    }
    public void PickUpFront()
    {        
        playerAnimator.SetBool("Idle", false);
        playerAnimator.SetBool("Moving", true);
        playerAnimator.SetTrigger("PickUpFront");        
    }
    public void OpenDoor()
    {
        playerAnimator.SetBool("Idle", false);
        playerAnimator.SetBool("Moving", true);
        playerAnimator.SetTrigger("OpenDoor");
    }

    //evento de animacion pickUpFront(); //aca tambien 
    public void PickUpNow()
    {
        if (playerController.focus.tag == "Object")
        {
            playerController.focus.PickUpItem();
        }
        else if (playerController.focus.tag == "FuseBox") //deberia ir en USENOW pero no tenemos otra animacion que no sea pickupnow
        {
            playerController.focus.UseNow();
        }               
               
    }
    //evento de animacion OpenDoor();
    public void OpenNow()
    {
        if(playerController.focus.tag == "Door")
            playerController.focus.OpenDoor();
    }
    
    //evento de animacion UseNow(); ESTA ANIMACION NO EXISTE, USAMOS PICKUPFRONT
    public void UseNow()
    {
        //playerController.focus.Interact();
    }


}
