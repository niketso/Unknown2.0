using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    Vector2 v2 = new Vector2 (0,0f);

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventoryPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel, Input.mousePosition))
        {
            Debug.Log("Drop Item" + eventData.position);
            v2 = eventData.position;
            Ray ray = Camera.current.ScreenPointToRay(v2);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {                
                if (this.gameObject.name == "Key")
                {
                    Debug.Log("es key");
                    if (hit.transform.name == "Door" && hit.transform.GetComponent<ItemOpen>().isLocked)
                    {
                        Debug.Log("es puerta y esta locked");
                        hit.transform.GetComponent<ItemOpen>().isLocked = false;
                        Inventory.instance.RemoveItem(this.gameObject.GetComponent<ItemPickup>().item);
                    }
                }
            }
        }
    }
}
