using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 destination;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Destination")
                {
                    destination = hit.point;
                    player.GetComponent<PlayerMovement>().Walk(destination);
                }

                if (hit.transform.tag == "Object")
                {

                }

            }

        }
    }

}
