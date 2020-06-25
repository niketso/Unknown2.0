﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform inventoryPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(inventoryPanel,Input.mousePosition))
        {
            Debug.Log("Drop Item");
        }
    }

   
}
