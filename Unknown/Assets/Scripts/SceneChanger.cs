using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "Player")
        {
            SceneManager.LoadScene("TestScene 1");
            AudioManager.instance.Play("AmbientHorror", true);
            
        }
    }
}
