using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public CameraController cc;
    private Camera rayCamera;
    public bool isObj = false;
    public bool isDoor = false;

    Vector3 destination;

    public Interactable focus;

    //private int layerMask;

    private void Awake()
    {
        //layerMask = ~LayerMask.GetMask("Player");
    }
    void Update()
    {
        rayCamera = cc.currentCam;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Input.GetMouseButtonDown(0) && !(Cursor.lockState == CursorLockMode.Locked))
        {

            if (Physics.Raycast(ray, out hit, 100/*, layerMask*/))
            {
                //Player Movement
                if (hit.transform.tag == "Destination" && !EventSystem.current.IsPointerOverGameObject())
                {                    
                    destination = hit.point;
                    player.GetComponent<PlayerMovement>().Walk(destination);
                    isObj = false; // es necesaria esta linea?
                    RemoveFocus();
                }
                //Player interaction with objects
               if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "Object" && !EventSystem.current.IsPointerOverGameObject())
                 {

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                    {
                        SetFocus(interactable);
                    }

                }

                //Door Open
                if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "Door" && !EventSystem.current.IsPointerOverGameObject())
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
            destination = newFocus.transform.position + new Vector3(-0.5f, 0, 0);
            player.GetComponent<PlayerMovement>().Walk(destination);

            //Chequea que tipo de Interactable es
            if (newFocus.tag == "Object")
                isObj = true;
            else if (newFocus.tag == "Door")                
                isDoor = true; //Para cuando este la animacion de la puerta
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
