using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public GameObject destination;
    public Vector3 destinationPos;
    void Start()
    {
       destinationPos = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entre");
            other.GetComponent<NavMeshAgent>().destination = destinationPos;
        }
    }
}
