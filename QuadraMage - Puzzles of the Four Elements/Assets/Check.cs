using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    public Button button;
    public Player player;
    ItemCollector collector;
    void Start()
    {
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Get the Player component from the playerObject
            player = playerObject.GetComponent<Player>();
             
        }

        button = GetComponent<Button>();
        
    }

    
    void Update()
    {
        /*
        if (ItemCollector.getKeys() == 1)
        {
            button.enabled = true;
        }
        else if (collector.getKeys() == 0)
        {
            button.enabled = false;
        }
        */
    }
}
