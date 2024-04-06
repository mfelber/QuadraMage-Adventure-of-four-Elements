using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ropePrefab;
    public bool ropeDestroyed;
    void Start()
    {
        ropeDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // earthELemntShot
        if(collision.gameObject.CompareTag("EarthElementShot"))
        {
            //Destroy(ropePrefab);
            ropePrefab.SetActive(false);
            ropeDestroyed = true;
        }
    }


}
