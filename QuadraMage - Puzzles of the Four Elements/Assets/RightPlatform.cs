using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlatform : MonoBehaviour
{
    public float weight;
    void Start()
    {
        weight = 0;
    }

    public float getWeight
    {
        get { return weight; }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.SetParent(transform);
            
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {                
                float playerWeight = playerRigidbody.mass;
                weight += playerWeight;     
               
            }
            
        }

        if (collision.gameObject.CompareTag("Iron"))
        {
            Rigidbody2D iron = collision.gameObject.GetComponent<Rigidbody2D>();
            //GameObject ironBox = GameObject.FindGameObjectWithTag("Iron");
            //ironBox.transform.SetParent(transform); 
            collision.transform.SetParent(transform);
            if (iron != null)
            {
                float ironBoxWeight = iron.mass;
                weight += ironBoxWeight;
            }
        }

        if (collision.gameObject.CompareTag("Box"))
        {
            GameObject boxx = GameObject.FindGameObjectWithTag("Box");
            //boxx.transform.SetParent(transform);
            collision.transform.SetParent(transform);
            Rigidbody2D box = collision.gameObject.GetComponent<Rigidbody2D>();
            if (box != null)
            {
                float boxweight = box.mass;
                weight += boxweight;                
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.parent = null;

            if (playerRigidbody != null)
            {               
                float playerWeight = playerRigidbody.mass;
                weight -= playerWeight;                         
            }
            
        }


        if (collision.gameObject.CompareTag("Iron"))
        {
            Rigidbody2D ironBox = collision.gameObject.GetComponent<Rigidbody2D>();
            //GameObject iron = GameObject.FindGameObjectWithTag("Iron");
            //iron.transform.SetParent(null);
            collision.transform.SetParent(null);
            if (ironBox != null)
            {         
                float ironWeightBox = ironBox.mass;
                weight -= ironWeightBox;
            }
        }


        if (collision.gameObject.CompareTag("Box"))
        {
            Rigidbody2D boxRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            //GameObject box = GameObject.FindGameObjectWithTag("Box");
            //box.transform.SetParent(null);

            if (boxRigidbody != null)
            {
                float boxweight = boxRigidbody.mass;
                weight -= boxweight;               
            }
            collision.transform.SetParent(null);
        }
    }

    void Update()
    {
        
    }
}