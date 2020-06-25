using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }

        instance = this;
    }

    //suscribir varios metodos a un mismo evento.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

     public int inventorySize = 2; 

    public List<Item> itemsList = new List<Item>();

    public bool AddItem(Item itemToAdd)
    {

        if (itemsList.Count >= inventorySize)
        {
            Debug.Log("Not enought room.");
            return false;
        }
        itemsList.Add(itemToAdd);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item itemToRemove)
    {
        itemsList.Remove(itemToRemove);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
