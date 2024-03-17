using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 16);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject,0.1f);
            Destroy(collision.gameObject);
        }
    }
}
