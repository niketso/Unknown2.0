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
    PopUpController popUpController = null;
    [HideInInspector]
    public string playerSays = "The fire's blocking the exit";
    void Start()
    {
        destinationPos = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
        AudioManager.instance.Play("Fire",true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entre");
            other.GetComponent<NavMeshAgent>().destination = destinationPos;
            popUpController.PlayerWindow(playerSays);
            Invoke("DisablePopUp", 3);
        }
    }

    void DisablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }
}
