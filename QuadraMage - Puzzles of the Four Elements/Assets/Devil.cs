using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devil : MonoBehaviour
{
    public GameObject firstHornDown;
    public bool firstHornDownBool;
    void Start()
    {
        firstHornDown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            firstHornDown.SetActive(true);
            firstHornDownBool = true;
        }
    }
}
