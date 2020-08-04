using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAlarm : MonoBehaviour
{
    private bool alarmOn = false;

    void Update()
    {
        if (alarmOn)
        {
            //sonido
            //AudioManager.instance.Play("",true);
        }
    }

    public void TurnOnAlarm()
    {
        alarmOn = true;
    }
}
