﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChange : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public CameraController cc;

    private void OnTriggerEnter(Collider other)
    {
        cc.currentCam = cam;
        cc.CameraEnable();
    }
}