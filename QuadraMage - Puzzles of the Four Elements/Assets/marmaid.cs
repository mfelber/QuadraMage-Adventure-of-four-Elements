using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marmaid : MonoBehaviour
{
    // Start is called before the first frame update
    teleportToPoseidon TeleportToPoseidon;
    void Start()
    {
        TeleportToPoseidon = FindObjectOfType<teleportToPoseidon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("kolizia");
            TeleportToPoseidon.teleportPlayer();
        }
    }
}
