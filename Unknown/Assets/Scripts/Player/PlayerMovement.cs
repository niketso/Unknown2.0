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

    private void Arrived() //Activa la animacion segun que tipo de interactuable es
    {
        if (playerController.isObj)
        {
            playerAnimator.PickUpFront();
            playerController.isObj = false; //esto por que era? Asi lo comentamos bien. 
        }
        else if (playerController.isDoor)
        {
            playerAnimator.OpenDoor();
            playerController.isDoor = false; //evidentemente no sale de la animacion sin esta linea
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
     
    
     




    
 



