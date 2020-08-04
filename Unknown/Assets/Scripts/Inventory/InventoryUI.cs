using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;
    
    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
    private void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        //Debug.Log("updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemsList.Count)
            {
                slots[i].AddItem(inventory.itemsList[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
