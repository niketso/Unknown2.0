using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    public string itemText;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {     
        transform.Find("Text").GetComponent<Text>().text = itemText; 
    }
    

}
