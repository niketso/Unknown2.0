using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private PlayerAnimator playerAnimator;
    private PlayerController playerController;
    private Vector3 playerPosition;
    public bool moved = false;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerController = FindObjectOfType<PlayerController>();      
    }

    private void Arrived() //Activa la animacion segun que tipo de interactuable es
    {
        //Debug.Log("Remaining Distance>> " + agent.remainingDistance);
        agent.isStopped = true;
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
        agent.isStopped = false;     
        if (!playerAnimator.pickingUp)
        {            
            agent.destination = destination;
            playerAnimator.Walk();
            moved = true;   
        }           
    }   

    private void Update()
    {
        Debug.Log("Destination: " + agent.destination);
        if (moved == true && agent.remainingDistance <= 0.1 && playerAnimator.pickingUp == false)
        {
            Arrived();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;            
        }
        else if (moved == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;           
        }
    }
    


    
}
     
    
     




    
 



