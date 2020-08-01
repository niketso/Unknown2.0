using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOpen : Interactable
{
    [SerializeField]
    public bool isLocked;
    public override void Interact()
    {
        base.Interact();

        Open();
    }

    public void Open()
    {
        Debug.Log("OPEN");
        if (isLocked == false)
            this.GetComponentInParent<Animator>().SetTrigger("OpenDoor");
    }
}
