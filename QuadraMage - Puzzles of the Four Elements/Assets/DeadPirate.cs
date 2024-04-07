using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPirate : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator pirateAnimator;
    public GameObject pirate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("cage"))
        {
            pirateAnimator.SetBool("dead", true);
            Destroy(pirate,1.1f);
        }
    }
}
