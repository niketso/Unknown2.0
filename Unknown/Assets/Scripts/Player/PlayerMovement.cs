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
    private Animator animatorController;
    public bool moving = false;
    //private float rotationSpeed = 1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponent<PlayerAnimator>();
        playerController = FindObjectOfType<PlayerController>();
        playerPosition = this.transform.position;
        animatorController = GetComponent<Animator>();      
    }

    private void Start()
    {
        InputManager.instance.UnlockMouse();    
    }
    private void Arrived() 
    {
        //Debug.Log("ENTRO ARRIVED");
                       
        if (AudioManager.instance.SoundPlaying("StepsConcrete"))
        {
            AudioManager.instance.StopSound("StepsConcrete");
        }                
               
        if (playerController.isObj)
        {
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
            playerAnimator.PickUpFront();
            playerController.isFuseBox = false;
            
        }
        else if (playerController.isFireAlarm)
        {
            //Debug.Log("enable 5");
            playerAnimator.OpenDoor();
            playerController.isFireAlarm = false;
            
        }
        else if (playerController.isPuzzle)
        {
            //Debug.Log("enable 4");
            InputManager.instance.UnlockMouse();
            playerAnimator.OpenDoor();
            playerController.isPuzzle = false;
            
        }
        else if (!playerController.focus && !playerAnimator.pickingUp)
        {
            //Debug.Log("ARRIVED SIN FOCUS");
            //Debug.Log("enable 3");
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
            //Debug.Log("MOVING = FALSE");         
            agent.isStopped = true;            
            moving = false;
            Arrived();
        }

        if (animatorController.GetBool("Moving"))
        {
            if (playerController.focus != null)
            {
                iTween.LookTo(this.gameObject, playerController.focus.transform.position, 1);
            }            
        }
    }
}




    
 



