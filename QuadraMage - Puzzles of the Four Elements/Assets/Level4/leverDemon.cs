using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverDeamon : MonoBehaviour
{
    public Animator leverAnimator;
    public Animator BridgeAnimator;
    public bool hit;


    void Start()
    {
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            BridgeAnimator.SetBool("down", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            leverAnimator.SetBool("hitByDeamon",true);
            hit = true;
        }
    }

}
