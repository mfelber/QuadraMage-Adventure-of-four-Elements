using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampFire : MonoBehaviour
{

    public GameObject tiny , small, medium, large;
    int stage;

    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = tiny;
        tiny.SetActive(true);
        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);

        stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            Destroy(collision.gameObject);  
            stage++;
            // mozno carateen ked bude animacia ze ju postupne pustim
            if (stage == 2)
            {
                tiny.SetActive(false);
                small.SetActive(true);
                
            }
            if (stage == 3)
            {
                
                small.SetActive(false);
                medium.SetActive(true);
                
            }
            if(stage == 4)
            {
                //small.SetActive(false);
                medium.SetActive(false);
                large.SetActive(true);
            }
        }
    }
}
