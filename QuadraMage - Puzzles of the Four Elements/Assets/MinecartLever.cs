using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecartLever : MonoBehaviour
{
    public Animator minecartAnimator;
   
    public bool leverIsActive;
    public GameObject arrow;
    void Start()
    {
        //arrow = GetComponent<Animator>();
        arrow.SetActive(true);
        
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
        
        leverIsActive = true;
        
        minecartAnimator.SetBool("go", true);
        
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
    }


    public bool getLever
    {
        get { return leverIsActive; }
    }

   
}
