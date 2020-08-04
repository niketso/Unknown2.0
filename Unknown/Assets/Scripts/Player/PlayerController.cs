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
    public bool isFuseBox = false;
    public bool isFireAlarm = false;
    public bool isPuzzle = false;

    Vector3 destination;

    public Interactable focus;

    void Update()
    {
        rayCamera = cc.currentCam;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (Input.GetMouseButtonDown(0) && !(Cursor.lockState == CursorLockMode.Locked))
        {

            if (Physics.Raycast(ray, out hit, 100))
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

                if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "FireAlarm" && !EventSystem.current.IsPointerOverGameObject())
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }

                if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "FuseBox" && !EventSystem.current.IsPointerOverGameObject())
                {                  
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }

                if (hit.collider.GetComponent<Interactable>() && hit.transform.tag == "Puzzle" && !EventSystem.current.IsPointerOverGameObject())
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
            //Esto es para que no frene tan lejos
            if (newFocus.tag == "FuseBox")
            {
                destination = newFocus.GetComponent<ItemUse>().stopingZonePos;
                player.GetComponent<PlayerMovement>().Walk(destination);
                isFuseBox = true;
            }
            else if (newFocus.tag == "FireAlarm")
            {
                destination = newFocus.GetComponent<FireAlarm>().stopingZonePos;
                player.GetComponent<PlayerMovement>().Walk(destination);
                isFireAlarm = true;
            }
            else if (newFocus.tag == "Object")
            {
                destination = newFocus.GetComponent<ItemPickup>().stopingZonePos;
                player.GetComponent<PlayerMovement>().Walk(destination);
                isObj = true;
            }
            else if (newFocus.tag == "Puzzle")
            {
                destination = newFocus.GetComponent<PuzzleItem>().stoppingZonePos;
                player.GetComponent<PlayerMovement>().Walk(destination);
                isPuzzle = true;
            }
            else
            {
                destination = newFocus.transform.position + new Vector3(-0.5f, 0, 0);
                player.GetComponent<PlayerMovement>().Walk(destination);
            }

            //Chequea que tipo de Interactable es
             if (newFocus.tag == "Door")
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
