using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cagesController : MonoBehaviour
{
    public GameObject cage;
    
   

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
            Destroy(gameObject,1);
        }

        
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            Destroy(gameObject, 1);
        }
        


    }
}
