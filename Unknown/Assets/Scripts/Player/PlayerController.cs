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
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    if (interactable != null)
                    {
                        Debug.Log("interactable, " + interactable.name);
                        SetFocus(interactable);
                    }
                    else
                    {
                        if (hit.transform.gameObject.CompareTag("Destination"))
                        {
                            Debug.Log("destinatination " + hit.transform.name);
                            destination = hit.point;
                            player.GetComponent<PlayerMovement>().Walk(destination);
                           // isObj = false; // es necesaria esta linea?
                            RemoveFocus();
                        }
                    }
                }
                else
                {
                    Debug.Log("Click dentro del HUD");
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

            destination = newFocus.GetComponent<ItemUse>().stopingZonePos;
            player.GetComponent<PlayerMovement>().Walk(destination);

            if (newFocus.tag == "FuseBox")
            {                
                isFuseBox = true;
            }
            else if (newFocus.tag == "FireAlarm")
            {                
                isFireAlarm = true;
            }
            else if (newFocus.tag == "Object")
            {                
                isObj = true;
            }
            else if (newFocus.tag == "Puzzle")
            {                
                isPuzzle = true;
            }
            else if (newFocus.tag == "Door")
            {                
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
