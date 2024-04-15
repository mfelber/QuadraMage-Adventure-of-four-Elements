using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    public GameObject firstHornDown;
    public static bool firstHornDownBool;
    void Start()
    {
        firstHornDown.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            firstHornDown.SetActive(false);
            firstHornDownBool = true;
            Destroy(collision.gameObject);
        }
    }
}
