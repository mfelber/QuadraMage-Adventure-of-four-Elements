using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartLever : MonoBehaviour
{
    public Animator minecartAnimator;
   
    public bool leverIsActive;
    public GameObject arrow;
   // public Sprite leverOn, leverOff;
    public GameObject leverOn, leverOff;
    void Start()
    {
        //arrow = GetComponent<Animator>();
        arrow.SetActive(true);
        leverOn.SetActive(false);
        leverOff.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.inRangeOfMineCartLever == true && Input.GetKeyDown(KeyCode.E) && leverIsActive == false)
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
        
        minecartAnimator.SetBool("go", true);
       /// GetComponent<SpriteRenderer>().sprite = leverOn;


        Invoke("deactivateLever", 1.5f);
        
        
    }

    public void deactivateLever()
    {
        
        minecartAnimator.SetBool("go", false);         
        StartCoroutine(leverisActive());
        
    }

    IEnumerator leverisActive ()
    {
        yield return new WaitForSeconds(3f);
        
        leverIsActive = false;
        leverOn.SetActive(false);
        leverOff.SetActive(true);
        // GetComponent<SpriteRenderer>().sprite = leverOff;
    }


    public bool getLever
    {
        get { return leverIsActive; }
    }

   
}
