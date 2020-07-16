using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
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
        if (!playerAnimator.pickingUp)
        {
            agent.destination = destination;
            playerAnimator.Walk();
        }
    }   

    private void Update()
    {        
        if (agent.remainingDistance < 0.1 && playerAnimator.pickingUp == false)
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
     
    
     




    
 



