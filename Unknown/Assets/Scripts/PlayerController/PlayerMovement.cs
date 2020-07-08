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
    public void Walk(Vector3 destination)
    {
        agent.destination = destination;
        moving = true;
        playerAnimator.Walk();      
    }
     private void Arrived()
    {
        moving = false;
        playerAnimator.Idle();
    }

}
