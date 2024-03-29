using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float weight;
    public GameObject startterBox;
    void Start()
    {
        weight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    
    public float getWeight
    {
        get { return weight; }
    }
    public static bool playerOnPlat;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            playerOnPlat = true;
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.transform.SetParent(transform);
            collision.transform.SetParent(transform);

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

        if (collision.gameObject.CompareTag("StartBox"))
        {
            Rigidbody2D box = collision.gameObject.GetComponent<Rigidbody2D>();
            if (box != null)
            {
                float boxweight = box.mass;
                weight += boxweight;
                Debug.Log("Hmotnost boxu je: " + boxweight);
                Invoke("destroySrtterBox", 1);               
               
            }

        }

    }


    public void destroySrtterBox ()
    {
        Destroy(startterBox, 2);
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlat = false;
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
            collision.transform.SetParent(null);

            if (boxRigidbody != null)
            {
                float boxweight = boxRigidbody.mass;
                weight -= boxweight;
            }
        }
        if (collision.gameObject.CompareTag("StartBox"))
        {
            GameObject box = GameObject.FindGameObjectWithTag("StartBox");
            Rigidbody2D boxRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            // box.transform.SetParent(transform);

            if (boxRigidbody != null){
                

                float boxweight = boxRigidbody.mass;
                weight -= boxweight;                
                
            }
        }


    }

    public void setWeight()
    {
        
    }
 


}
