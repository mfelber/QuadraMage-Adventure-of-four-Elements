using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar : MonoBehaviour
{
    public List<Item.ItemData> inventar = new List<Item.ItemData>();

    public void PridatDoInventara(Item.ItemData itemData)
    {
        inventar.Add(itemData);
        Debug.Log("Polo�ka " + itemData.itemName + " pridan� do invent�ra.");
    }
}
