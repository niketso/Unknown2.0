using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChange : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public Camera prevCam;
    [SerializeField] public CameraController cc;

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