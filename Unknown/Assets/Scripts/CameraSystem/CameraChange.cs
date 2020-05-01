using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChange : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Camera prevCam;
    [SerializeField] private CameraController cc;

    private void OnTriggerEnter(Collider other)
    {        
        if (cc.currentCam == cam)
        {
            cc.currentCam = prevCam;
            cc.CameraEnable();
        }
        else
        {
            cc.currentCam = cam;
            cc.CameraEnable();
        }
    }
        
}