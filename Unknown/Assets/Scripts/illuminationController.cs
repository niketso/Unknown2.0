using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illuminationController : MonoBehaviour
{
    [SerializeField]
    public GameObject[] emergencyLights;
    [SerializeField]
    public GameObject[] normalLights;

    private void Start()
    {
        for (int i = 0; i < emergencyLights.Length; i++)
        {
            emergencyLights[i].SetActive(true);
        }
        for (int i = 0; i < normalLights.Length; i++)
        {
            normalLights[i].SetActive(false);
        }
    }

    public void ChangeLights()
    {
        for (int i = 0; i < normalLights.Length; i++)
        {
            normalLights[i].SetActive(true);
        }

        for (int i = 0; i < emergencyLights.Length; i++)
        {
            emergencyLights[i].SetActive(false);
        }
    }
}
