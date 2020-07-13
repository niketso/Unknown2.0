using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;
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

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pick Up Front"))
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
        playerAnimator.SetBool("Moving", true);
        playerAnimator.SetBool("Idle", false);
    }
    public void PickUpFront()
    {        
        playerAnimator.SetBool("Idle", false);
        playerAnimator.SetBool("Moving", true);
        playerAnimator.SetTrigger("PickUpFront");        
    }

    void PickUpNow()
    {
    }
    

        
}
