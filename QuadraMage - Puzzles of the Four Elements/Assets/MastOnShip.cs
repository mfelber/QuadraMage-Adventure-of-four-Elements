using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastOnShip : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public GameObject endingbridgeHinge;
    public GameObject startingBridgehinge;
    public GameObject Bridge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("fall", true);
            endingbridgeHinge.SetActive(false);
            Invoke("destroyStartingHinge", 2.5f);
        }
    }

    public void destroyStartingHinge()
    {

        startingBridgehinge.SetActive(false);
        Invoke("destroyBridge", 2.5f);
        
    }

    public void destroyBridge ()
    {
        Bridge.SetActive(false);
    }
}
