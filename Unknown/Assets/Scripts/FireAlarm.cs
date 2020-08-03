using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarm : Interactable
{
    public bool isUsable = false;
    [SerializeField]
    GameObject fire;

    public override void Interact()
    {
        base.Interact();

        Use();
    }

    public void Use()
    {
        Debug.Log("Use fire allarm");
        if (isUsable == true)
        {
            Destroy(fire);
        }
        else
        {
            //aca el texto de no hay luz
        }
    }
}
