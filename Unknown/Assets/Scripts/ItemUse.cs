using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : Interactable
{
    [SerializeField]
    GameObject otherObject;
    
    public override void Interact()
    {
        base.Interact();

        Use();
    }

    public void Use()
    {
        Debug.Log("USE");
        //habilitar alarma
        otherObject.gameObject.GetComponent<FireAlarm>().isUsable = true;   
       
    }
}
