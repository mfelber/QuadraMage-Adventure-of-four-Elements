using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class CampFire : MonoBehaviour
{

    public Sprite tiny , small, medium, large;
    int stage;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tiny;
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
            stage++;
            // mozno carateen ked bude animacia ze ju postupne pustim
            if (stage == 2)
            {
                GetComponent<SpriteRenderer>().sprite = small;
            }
            if (stage == 3)
            {
                GetComponent<SpriteRenderer>().sprite = medium;
            }
            if(stage == 4)
            {
                GetComponent<SpriteRenderer>().sprite = large;
            }
        }
    }
}
