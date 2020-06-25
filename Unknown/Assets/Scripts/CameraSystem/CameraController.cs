using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{    
    [SerializeField] public Camera camera0;
    public Camera currentCam;  
    private void Start()
    {
        
        CameraSet();
        currentCam = camera0;
    }
    void CameraSet()
    {        
        for (int i = 1; i < Camera.allCameras.Length; i++)
            Camera.allCameras[i].enabled = false;
        currentCam.enabled = true;
    }
    public void CameraEnable()
    {
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera.allCameras[i].enabled = false;
        }
        currentCam.enabled = true;
    }
}