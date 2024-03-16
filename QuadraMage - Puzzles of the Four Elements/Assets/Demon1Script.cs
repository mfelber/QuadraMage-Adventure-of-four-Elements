using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon1Script : MonoBehaviour
{
    public Animator deamonAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // mozno aj voda nieco spravi a aj zem ?
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            deamonAnimator.SetBool("hit", true);
            Invoke("hitToFalse",2);
        }
    }

    public void hitToFalse()
    {
        deamonAnimator.SetBool("hit", false);
    }
}
