using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    [SerializeField] GameObject stopingZone = null;
    public Vector3 stopingZonePos;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
    }

    public override void Interact()
    {
        base.Interact();
    }

    public void PickUp()
    {
        //Debug.Log("Picking up " + item.name);
        AudioManager.instance.Play("PickUp", false);
        Inventory.instance.AddItem(item);       
    }
    
}
