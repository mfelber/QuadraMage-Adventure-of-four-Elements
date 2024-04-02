using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartLever : MonoBehaviour
{
    public Animator minecartAnimator;
   
    private bool leverIsActive;
    public GameObject arrow;
   // public Sprite leverOn, leverOff;
    [SerializeField] private GameObject leverOn, leverOff;
    public CinemachineVirtualCamera vcam;
    public Transform player;
    public Transform minecart;
    bool nearLever;
    MinecartHanging minecartHanging;
    
    void Start()
    {
        //arrow = GetComponent<Animator>();
        arrow.SetActive(true);
        leverOn.SetActive(false);
        leverOff.SetActive(true);
        minecartHanging = FindObjectOfType<MinecartHanging>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nearLever == true && Input.GetKeyDown(KeyCode.E) && leverIsActive == false)
        {
            activateMinecartLever();            
        }

        if (leverIsActive == false)
        {
            arrow.SetActive(true);
        } else
        {
            arrow.SetActive(false);
        }
        
    }

    public void activateMinecartLever()
    {
        
        leverOn.SetActive(true);
        leverOff.SetActive(false);
        leverIsActive = true;
        
        if (minecartHanging.minecartHanging == false)
        {
            minecartAnimator.SetBool("go", true);
            vcam.Follow = minecart;
            PlayerMovement.isInputEnabled = false;
        }
       
       /// GetComponent<SpriteRenderer>().sprite = leverOn;


        Invoke("deactivateLever", 1.5f);
        
        
    }

    public void deactivateLever()
    {
        if (minecartHanging.minecartHanging == false)
        {
            minecartAnimator.SetBool("go", false);
        }
        StartCoroutine(leverisActive());
        
    }

    IEnumerator leverisActive ()
    {
        if (minecartHanging.minecartHanging == false)
        {
            yield return new WaitForSeconds(2f);
            vcam.Follow = player;
            PlayerMovement.isInputEnabled = true;
            yield return new WaitForSeconds(3f);

            leverIsActive = false;
            leverOn.SetActive(false);
            leverOff.SetActive(true);
        } else
        {
            leverIsActive = false;
            leverOn.SetActive(false);
            leverOff.SetActive(true);
        }
       
        // GetComponent<SpriteRenderer>().sprite = leverOff;
    }


    public bool getLever
    {
        get { return leverIsActive; }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            nearLever = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nearLever = false;
        }
    }

   
}
