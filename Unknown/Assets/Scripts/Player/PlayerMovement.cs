using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool moving = false;
    private PlayerAnimator playerAnimator;
    private PlayerController playerController;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerController = FindObjectOfType<PlayerController>();

    }


    private void Arrived()
    {
        moving = false;  
        
        if (playerController.isObj)
        {
            playerAnimator.PickUpFront();
            playerController.isObj = false;
        }
        else
        {
            playerAnimator.Idle();
        }
    }

    public void Walk(Vector3 destination)
    {
        agent.destination = destination;
        moving = true;
        playerAnimator.Walk();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1)
        {
            Arrived();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
     
    
     




    
 



