using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockFirstPlayerAttack : MonoBehaviour
{
    
    void Start()
    {
        Physics2D.IgnoreLayerCollision(15, 16);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OneWayPlatform"))
        {
            Invoke("changeMass", 0.5f);
            
        }


    }

    public void changeMass()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = 0.7f;
    }
}
