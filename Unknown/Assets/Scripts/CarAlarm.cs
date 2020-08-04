using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CarAlarm : MonoBehaviour
{
    public bool alarmOn = false;
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject zombieObstacle;
    [SerializeField] GameObject destinationPos;
    private Vector3 destinationPosVec;
    float dist;

    private void Start()
    {
        destinationPosVec = new Vector3(destinationPos.transform.position.x, destinationPos.transform.position.y, destinationPos.transform.position.z);
        
    }
    void Update()
    {
        if (alarmOn)
        {
            //sonido
            //AudioManager.instance.Play("",true);
            zombie.GetComponent<NavMeshAgent>().SetDestination(destinationPosVec);
            zombie.GetComponent<Animator>().SetTrigger("Move");
            zombie.GetComponent<Animator>().SetBool("Walking",true);
        }

        UpdateDistance();
        if (zombie.GetComponent<NavMeshAgent>().remainingDistance < 0.5)
        {
            zombie.GetComponent<Animator>().SetBool("Walking", false);
            zombieObstacle.GetComponent<ZombieObstacle>().hasArrived = true;
        }
    }

    public void TurnOnAlarm()
    {
        alarmOn = true;
    }

    public void UpdateDistance()
    {
        dist = Vector3.Distance(zombie.transform.position, destinationPos.transform.position);
    }
}
