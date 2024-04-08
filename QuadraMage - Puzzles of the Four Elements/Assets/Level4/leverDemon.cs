using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverDeamon : MonoBehaviour
{
    
    public Animator BridgeAnimator;
    public GameObject leverOff, leverOn;
    public bool hit;


    void Start()
    {
        hit = false;
        leverOff.SetActive(true);
        leverOn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            BridgeAnimator.SetBool("down", true);
            leverOff.SetActive(false);
            leverOn.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            hit = true;
        }
    }

}
