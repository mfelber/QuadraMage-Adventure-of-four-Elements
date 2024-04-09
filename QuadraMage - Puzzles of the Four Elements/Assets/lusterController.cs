using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lusterController : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Tnt"))
        {
            Destroy(gameObject, 1);
        }

        if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject, 1);
        }

        if (collision.gameObject.CompareTag("Bridge"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject, 0.6f);

        }
    }
}
