using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CarAlarm : MonoBehaviour
{
    public bool alarmOn = false;
    public bool zombieMoved = false;      
    [SerializeField] GameObject zombie = null;
    [SerializeField] GameObject zombieObstacle = null;
    [SerializeField] GameObject destinationPos = null;
    private Vector3 destinationPosVec;
    float dist;
    [SerializeField] public GameObject gateControl;


    private void Start()
    {
        destinationPosVec = new Vector3(destinationPos.transform.position.x, destinationPos.transform.position.y, destinationPos.transform.position.z); 
               
    }

    private void Update()
    {        
        ZombieArrived();
    }

    public void TurnOnAlarm()
    {
        alarmOn = true;
        zombie.GetComponent<NavMeshAgent>().SetDestination(destinationPosVec);
        zombie.GetComponent<Animator>().SetTrigger("Move");
        zombie.GetComponent<Animator>().SetBool("Walking", true);
        InputManager.instance.LockMouse();
        zombieMoved = true;
    }

    public void ZombieArrived()
    {
        UpdateDistance();

        if (dist <= 0.6f && zombieMoved)
        {
            zombie.GetComponent<Animator>().SetBool("Walking", false);
            zombieObstacle.GetComponent<ZombieObstacle>().hasArrived = true;
            InputManager.instance.UnlockMouse();
            zombieMoved = false;
            gateControl.GetComponent<PuzzleItem>().isUsable = true;
        }
    }

    public void UpdateDistance()
    {
        dist = Vector3.Distance(zombie.transform.position, destinationPos.transform.position);
    }
}
