using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOpen : Interactable
{
    public override void Interact()
    {
        base.Interact();

        Open();
    }

    public void Open()
    {
        Debug.Log("OPEN");
        if (this.GetComponentInParent<Animator>().GetBool("IsLocked") == false)
            this.GetComponentInParent<Animator>().SetTrigger("OpenDoor");
    }
}
