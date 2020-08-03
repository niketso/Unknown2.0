using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarm : Interactable
{
    public bool isUsable = false;
    [SerializeField]
    GameObject fire;
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

        Activate();
    }

    public void Activate()
    {
        Debug.Log("Use fire alarm");
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
