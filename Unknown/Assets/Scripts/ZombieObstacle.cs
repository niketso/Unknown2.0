using UnityEngine.AI;
using UnityEngine;

public class ZombieObstacle : MonoBehaviour
{
    [SerializeField] public GameObject destination;
    [SerializeField] public GameObject car;
    public Vector3 destinationPos;
    [SerializeField] public PopUpController popUpController;
    [HideInInspector] public string playerSays = " 'Is that a zombie?' ";
    public bool hasArrived = false;

    private void Start()
    {
        destinationPos = new Vector3(destination.transform.position.x, destination.transform.position.y, destination.transform.position.z);
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            if (!(car.GetComponent<CarAlarm>().alarmOn))
            {
                other.GetComponent<NavMeshAgent>().destination = destinationPos;
                popUpController.PlayerWindow(playerSays);
                Invoke("DisablePopUp", 3);
            }
           
        }
    }

    void DisablePopUp()
    {
        popUpController.playerWindow.SetActive(false);
    }
}
