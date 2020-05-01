using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool moving = false;  

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Walk(Vector3 destination)
    {
        if (agent.remainingDistance < 0.1)
        {
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
    }

}
