using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private GameObject player;
    private Animator playerAnimator;
    private bool moving;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        moving = playerAnimator.GetBool("Moving");
        Idle();
    }              
    public void Idle()
    {
        Debug.Log("play Idle");
        playerAnimator.SetBool("Moving", false);
        //playerAnimator.SetTrigger("Idle"); 
    }
    public void Walk()
    {
        Debug.Log("play Walk");
        playerAnimator.SetBool("Moving", true);

    }
}
