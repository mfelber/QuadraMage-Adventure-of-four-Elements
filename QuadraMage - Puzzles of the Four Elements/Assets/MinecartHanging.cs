using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartHanging : MonoBehaviour
{
    public bool minecartHanging;
    public Animator aniamtor;
    bool playerNear;
    public GameObject leverOn, LeverOff;

    void Start()
    {
        //minecartRB = GetComponent<Rigidbody2D>();
        playerNear = false;
        minecartHanging = true;
        leverOn.SetActive(false);
        LeverOff.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear && Input.GetKey(KeyCode.E))
        {
            //Destroy(minecartRB);
            aniamtor.SetBool("fall",true);
            leverOn.SetActive(true);
            LeverOff.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNear = false;
        }
    }

   
    
}
