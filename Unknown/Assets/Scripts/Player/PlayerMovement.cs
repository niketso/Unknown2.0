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
    public bool moving = false;
    //private float rotationSpeed = 1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerController = FindObjectOfType<PlayerController>();
        playerPosition = this.transform.position;      
    }

    private void Start()
    {
        InputManager.instance.UnlockMouse();    
    }
    private void Arrived() 
    {
        Debug.Log("ENTRO ARRIVED");
                       
        if (AudioManager.instance.SoundPlaying("StepsConcrete"))
        {
            AudioManager.instance.StopSound("StepsConcrete");
        }                
               
        if (playerController.isObj)
        {
            InputManager.instance.UnlockMouse();
            playerAnimator.PickUpFront();
            playerController.isObj = false; 
        }
        else if (playerController.isDoor)
        {
            playerAnimator.OpenDoor();
            playerController.isDoor = false; 
        }
        else if (playerController.isFuseBox)
        {
            InputManager.instance.UnlockMouse();
            playerAnimator.PickUpFront();
            playerController.isFuseBox = false;
        }
        else if (playerController.isFireAlarm)
        {
            InputManager.instance.UnlockMouse();
            playerAnimator.OpenDoor();
            playerController.isFireAlarm = false;
        }
        else if (playerController.isPuzzle)
        {
            InputManager.instance.UnlockMouse();
            playerAnimator.OpenDoor();
            playerController.isPuzzle = false;
        }
        else if (/*!playerController.focus*/!playerAnimator.pickingUp)
        {
            Debug.Log("ARRIVED SIN FOCUS");
            InputManager.instance.UnlockMouse();
            playerAnimator.Idle();
        }
        
    }

    public void Walk(Vector3 destination)
    {
        agent.isStopped = false;      
        if(!playerAnimator.pickingUp)
        {
            moving = true;
            agent.SetDestination(destination);
            playerAnimator.Walk();           
            AudioManager.instance.Play("StepsConcrete",false);
        }           
    }   

    private void Update()
    {
        if (moving && agent.remainingDistance <= 0.01)
        {
            Debug.Log("MOVING = FALSE");         
            agent.isStopped = true;            
            moving = false;            
        }

        if (!moving)
        {
            if (playerController.focus != null)
            {
                iTween.LookTo(this.gameObject, playerController.focus.transform.position, 1);
            }
            Arrived();

        }

    }

}
     
    
     




    
 



