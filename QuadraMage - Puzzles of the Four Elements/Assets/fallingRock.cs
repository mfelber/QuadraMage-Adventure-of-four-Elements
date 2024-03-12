using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingRock : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
