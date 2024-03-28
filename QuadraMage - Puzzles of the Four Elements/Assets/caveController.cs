
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class caveController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject background;
    //public SpriteRenderer spriteRenderer;
    public float fadeDuration = 0.5f;
    //public SpriteRenderer Cave1;
    public Animator cave1;
    public Animator cave2;
    public Animator cave3;
    public Animator backGround;
    void Start()
    {
        //  cave1.SetActive(true);
        // cave2.SetActive(true);
        // background.SetActive(true);
        background.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        //    spriteRenderer.enabled = false;
        background.SetActive(true);
            cave1.Play("cave");
            cave2.Play("cave");
            backGround.Play("cave");
            

            //spriteRenderer.enabled = true;
            //backGround.Play("backGroundTransitionLevel2");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            backGround.Play("backGroundTransitionLevel2");
            //background.SetActive(false);
            cave1.Play("caveUnFade");
            cave2.Play("caveUnFade");
            backGround.Play("caveUnFade");

            //spriteRenderer.enabled = false;

        }
    }

    

}
