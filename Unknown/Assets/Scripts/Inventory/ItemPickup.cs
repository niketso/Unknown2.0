using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    [SerializeField] GameObject stopingZone = null;
    public Vector3 stopingZonePos;

    PlayerAnimator playerAnimator;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
        playerAnimator = player.GetComponent<PlayerAnimator>();
    }

    public override void Interact()
    {
        base.Interact();
    }

    public void PickUp()
    {
        //Debug.Log("Picking up " + item.name);
        Invoke("EnableMouse", 1);
        AudioManager.instance.Play("PickUp", false);
        Inventory.instance.AddItem(item);        
    }

    void EnableMouse()
    {
        Debug.Log("ENABLE MOUSE DE ITEM PICK UP");        
        playerAnimator.Idle();
        InputManager.instance.UnlockMouse();
    }

}
