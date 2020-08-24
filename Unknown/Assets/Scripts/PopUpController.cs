using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{
    [SerializeField]
    public GameObject playerWindow;
    [SerializeField]
    public GameObject mouseOverWindow;

    private void Start()
    {
        playerWindow.SetActive(false);
        mouseOverWindow.SetActive(false);

        AudioManager.instance.Play("Music", true);
    } 

    public void PlayerWindow(string _text)
    {
        playerWindow.SetActive(true);
        playerWindow.GetComponentInChildren<Text>().text = _text;
    }
    public void MouseOverWindow(string _text)
    {
        mouseOverWindow.SetActive(true);
        mouseOverWindow.GetComponentInChildren<Text>().text = _text;
    }
}
