using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {

            Destroy(gameObject, 1);
        }
    }
}
