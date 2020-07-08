using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public CameraController cc;
    private Camera rayCamera;
    private int layerMask;
    private int layerMask1;
    
    Vector3 destination;

    public Interactable focus;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Default");
        layerMask1 = LayerMask.GetMask("UI");
    }
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
                }

                //hit.transform.gameObject.layer == LayerMask.NameToLayer("UI")
                Debug.Log(hit.transform.gameObject.layer);
                
               if (hit.transform.tag == "Destination"&& !(EventSystem.current.IsPointerOverGameObject()))
                 {
                        destination = hit.point;
                        player.GetComponent<PlayerMovement>().Walk(destination);
                        RemoveFocus();
                 }


               if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "Object" && !(EventSystem.current.IsPointerOverGameObject()))
                   {

                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                     {
                            SetFocus(interactable);

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
