using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBridge : MonoBehaviour
{

    public static bool infrontOfBridge = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            infrontOfBridge = true;
        }
    }
}
