using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranePlatform : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Tnt"))
        {
           
           
            //GameObject ironBox = GameObject.FindGameObjectWithTag("Iron");
            //ironBox.transform.SetParent(transform); 
            collision.transform.SetParent(transform);
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tnt"))
        {


            //GameObject ironBox = GameObject.FindGameObjectWithTag("Iron");
            //ironBox.transform.SetParent(transform); 
            collision.transform.SetParent(null);
            

        }
    }
}
