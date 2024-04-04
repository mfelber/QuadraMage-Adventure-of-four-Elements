using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ropePrefab;
    void Start()
    {
        
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
            Destroy(ropePrefab);
        }
    }


}
