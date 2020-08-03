using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour
{
    [SerializeField]
    PopUpController popUpController;
    string itemText;
   
    void Start()
    {
        itemText = this.GetComponent<Text>().text;
    }

    void OnMouseOver()
    {
        popUpController.MouseOverWindow(itemText);
    }

    void OnMouseExit()
    {
        popUpController.mouseOverWindow.SetActive(false);
    }
}
