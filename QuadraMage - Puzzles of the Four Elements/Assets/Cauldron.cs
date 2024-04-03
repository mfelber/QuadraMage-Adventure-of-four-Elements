using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{


    public float heat;
    public Animator cauldronAnimator;
    public Animator cauldronAnimator2;
    private enum PatroLeverStates { smoke, smokeHold,smokeMoving};
    public bool addHeat, cauldronFallBool;
    public int state;
    public GameObject cauldronFall, cauldronOnSticks;
    public bool hotWater;

    void Start()
    {
       addHeat = false;
        cauldronFall.SetActive(false);
        cauldronOnSticks.SetActive(true);
        cauldronFallBool = false;
        hotWater = false;
       
    }

   
    void Update()
    {

        if (addHeat)
        {
            heat += 0.5f;
            if (heat == 250)
            {
                // set states
             
                    cauldronAnimator.Play("cauldronBoiling");
                
               
                heat = 250;
                addHeat = false;

            }

        }

        
        if ( heat == 250 && cauldronFallBool)
        {
            cauldronAnimator2.Play("cauldronFall");
            hotWater = true;
        }

        if ( heat < 250 && cauldronFallBool)
        {
            cauldronAnimator2.Play("cauldronFall");
            hotWater = false;
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            cauldronFall.SetActive(true);
            cauldronOnSticks.SetActive(false);
            cauldronFallBool = true;
            Destroy(collision.gameObject,0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            addHeat = true;
        }


        

    }

    
}
