using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public CameraController cc;
    private Camera rayCamera;
    
    Vector3 destination;

    public Interactable focus;
    

    void Update()
    {
        rayCamera = cc.currentCam;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Input.GetMouseButtonDown(0))
        {
           
            if (Physics.Raycast(ray, out hit, 100))
            {
                    
                
                if (hit.transform.tag == "Destination")
                {
                    destination = hit.point;
                    player.GetComponent<PlayerMovement>().Walk(destination);
                    RemoveFocus();
                }


                if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "Object")
                {
                   
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        SetFocus(interactable);
                       // destination = interactable.transform.position;
                       //player.GetComponent<PlayerMovement>().Walk(destination);
 
                        //hit.collider.GetComponent<Interactable>().Interact();        
                    }
   
                }
            }

        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }

            focus = newFocus;
            destination = newFocus.transform.position + new Vector3(1.5f, 0, 0);
            player.GetComponent<PlayerMovement>().Walk(destination);
        }
   
        newFocus.OnFocused(player.transform);
                
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDeFocused();
        }
        focus = null;
    }

}
