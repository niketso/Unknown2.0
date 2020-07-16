using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    

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
