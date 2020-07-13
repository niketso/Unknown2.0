using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;
    private bool moving;
    public bool idle;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        moving = playerAnimator.GetBool("Moving");
        //idle = playerAnimator.GetBool("Idle");
        Idle();
    }              
    public void Idle()
    {
        Debug.Log("play Idle");
        
        playerAnimator.SetBool("Moving", false);
        //playerAnimator.SetBool("Idle", true);
        //playerAnimator.SetTrigger("Idle"); 
    }
    public void Walk()
    {
        Debug.Log("play Walk");
        playerAnimator.SetBool("Moving", true);
       //playerAnimator.SetBool("Idle", false);
    }
    public void PickUpFront()
    {
        Debug.Log("play PUFront");
        playerAnimator.SetBool("Moving", false);
    //playerAnimator.SetBool("Idle", false);
        playerAnimator.SetTrigger("PickUpFront");

    }
    
}
