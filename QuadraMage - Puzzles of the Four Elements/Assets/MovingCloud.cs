using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public GameObject MovingCloudPrefab;    
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {         
       
        if (collision.gameObject.CompareTag("WindElementShot") )
        {          
            rb.bodyType = RigidbodyType2D.Dynamic;           
            Invoke("setToStatic", 0.5f);
            
        }  

    }

    public void setToStatic()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }




}