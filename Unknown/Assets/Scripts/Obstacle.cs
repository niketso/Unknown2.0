using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] public GameObject destination;
    public Vector3 destinationPos;
    [HideInInspector]
    public Vector3 stopingZonePos;

    [SerializeField]
    PopUpController popUpController;
    [HideInInspector]
    public string playerSays = "The fire's blocking the exit";
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
            popUpController.PlayerWindow(playerSays);
            Invoke("disablePopUp", 3);
        }
    }

    void disablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }
}
