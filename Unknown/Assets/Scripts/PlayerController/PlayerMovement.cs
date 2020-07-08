using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool moving = false;
    private PlayerAnimator playerAnimator;  

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }
    void Update()
    {
        if (agent.remainingDistance < 0.1)
            Arrived();
        }
        else
        { 
            moving = true;
        }

        if(moving == false)  
        {
            agent.destination = destination;    
        }  
        else
        {
            Debug.Log("Already moving");
        }
    }
     private void Arrived()
    {    
        moving = false;
        playerAnimator.Idle();
    }


    private void Update()
    {
        if (agent.remainingDistance > 0.1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }




}
