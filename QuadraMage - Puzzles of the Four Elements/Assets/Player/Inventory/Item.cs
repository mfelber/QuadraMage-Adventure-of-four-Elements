using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
        public Sprite sprite;
        public string itemName;
    }

    public ItemData itemData;
}
