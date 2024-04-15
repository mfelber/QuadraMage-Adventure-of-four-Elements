using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDestroyPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(13, 16);
        Physics2D.IgnoreLayerCollision(6, 16);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
