using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : Interactable
{
    [SerializeField]
    GameObject stopingZone;
    [SerializeField]
    GameObject otherObject;
    public Vector3 stopingZonePos;

    public bool canUse = false;

    void Start()
    {
        stopingZonePos = stopingZone.transform.position;
    }

    public override void Interact()
    {
        base.Interact();
        Use();
    }

    public void Use()
    {
        Debug.Log("USE");
        //habilitar alarma
        otherObject.GetComponent<FireAlarm>().isUsable = true;          
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canUse = true;
        }
    }
}
