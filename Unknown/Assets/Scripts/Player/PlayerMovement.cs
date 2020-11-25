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
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;        
    }
    private void Arrived() 
    {               
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
            playerAnimator.OpenDoor();
            playerController.isFireAlarm = false;
        }
        else if (playerController.isPuzzle)
        {
            playerAnimator.OpenDoor();
            playerController.isPuzzle = false;
        }
        else
        {
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
            agent.isStopped = true;            
            moving = false;            
        }

        if (!moving)
        {

            if (playerController.focus != null)
                iTween.LookTo(this.gameObject, playerController.focus.transform.position, 1);

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
     
    
     




    
 



