using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    [SerializeField]
    GameObject stopingZone;
    public Vector3 stopingZonePos;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
    }

    public override void Interact()
    {
        base.Interact();

        //PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up " + item.name);        
        Inventory.instance.AddItem(item);       
    }
    
}
