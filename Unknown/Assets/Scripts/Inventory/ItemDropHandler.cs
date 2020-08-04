using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{

    private Camera cam;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventoryPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel, Input.mousePosition))
        {
           
            Item item = this.GetComponentInChildren<InventorySlot>().GetItem();
            //Debug.Log("nombre del item" + item.name);
            cam = CameraController.instance.GetCurrentCam();
            Ray ray = cam.ScreenPointToRay(eventData.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {                
                if (item.name == "Key")
                {
                   // Debug.Log("es key"+ "Choco contra" + hit.transform.name);
                    
                    if (hit.transform.name == "Door" && hit.transform.GetComponent<ItemOpen>().isLocked)
                    {
                       // Debug.Log("es puerta y esta locked");
                        hit.transform.GetComponent<ItemOpen>().isLocked = false;
                        Inventory.instance.RemoveItem(item);
                    }
                }
                else if(item.name == "Car Key")
                {
                    Debug.Log("es key"+ "Choco contra" + hit.transform.name);

                    if (hit.transform.name == "Car")
                    {
                        // Debug.Log("es puerta y esta locked");
                        hit.transform.GetComponent<CarAlarm>().TurnOnAlarm();
                        Inventory.instance.RemoveItem(item);
                    }
                }
            }
        }
    }
}
