using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;


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

                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                    {                        
                        SetFocus(interactable);
                    }
                    else
                    {
                        if (hit.transform.gameObject.CompareTag("Destination"))
                        {                           
                            destination = hit.point;                            
                            player.GetComponent<PlayerMovement>().Walk(destination);
                            isObj = false;
                            RemoveFocus();
                        }
                    }
                }
            }
        }
    }

    public void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDeFocused();
            }

            focus = newFocus;
           
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
            else if (newFocus.tag == "Door")
            {
                destination = newFocus.GetComponent<ItemOpen>().stoppingZonePos;
                player.GetComponent<PlayerMovement>().Walk(destination);
                isDoor = true;
            }

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
