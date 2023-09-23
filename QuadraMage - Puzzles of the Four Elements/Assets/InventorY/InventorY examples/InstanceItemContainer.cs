using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceItemContainer : MonoBehaviour
{
    // Start is called before the first frame update
    public ItemInstance item;
    public ItemInstance TakeItem()
    {
        Destroy(gameObject);
        return item;
    }
}
