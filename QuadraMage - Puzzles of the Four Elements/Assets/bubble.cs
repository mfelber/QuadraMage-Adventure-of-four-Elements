using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(12, 13);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.SetParent(null);
    }
    */
}
