using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaHorse : MonoBehaviour
{
    // Start is called before the first frame update
    teleportToPoseidon TeleportToPoseidon;
    
    private QuestManager questManager;

    void Start()
    {
        TeleportToPoseidon = FindObjectOfType<teleportToPoseidon>();
        
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            


        if (collision.gameObject.CompareTag("Player") && questManager.acceptSecondQuest == true)
        {

            TeleportToPoseidon.teleportPlayerToShip();

        }

    }
}
