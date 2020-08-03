using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    [SerializeField]
    GameObject popUpWindow;

    PopUpController popUpController;
    public string text;
    void Start()
    {
        text = GetComponent<Text>().text;
        popUpController = popUpWindow.GetComponent<PopUpController>();
    }

    void OnMouseOver()
    {
        popUpWindow.SetActive(true);
        popUpController.itemText = text;        
    }

    void OnMouseExit()
    {
        popUpWindow.SetActive(false);
    }
}
