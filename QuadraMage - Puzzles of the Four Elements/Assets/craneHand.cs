using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneHand : MonoBehaviour
{

    private bool craneNotdefault;
    public Animator craneHandAnimator;
    
   
    public GameObject hook;
   
    public Rigidbody2D tntBox;
    rope ropeScript;
    public bool animationGoing;
    

    void Start()
    {
        craneNotdefault = true;
        animationGoing = false;
        ropeScript = FindAnyObjectByType<rope>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (rope.ropeDestroyed)
        {
            tntBox.bodyType = RigidbodyType2D.Dynamic;
            
            Destroy(hook);
            
        }
        

        
    }

    public void animationIsGoing()
    {
        animationGoing = true;
    }


    public void animationIsStoped()
    {
        animationGoing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            Debug.Log("kolizia");
            if(craneNotdefault == true)
            {
          
                StopAllCoroutines();

                StartCoroutine(setRotateBool());
                craneHandAnimator.SetBool("rotate", true);
               
            }
            
        }

        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            if(craneNotdefault == false)
            {
               
                StopAllCoroutines();
                StartCoroutine(setRotateBool());
                craneHandAnimator.SetBool("rotate", false);
            }
           
        }
    }
    
    IEnumerator setRotateBool()
    {
        yield return new WaitForSeconds(1.5f);

        if (craneNotdefault == true)
        {
           
            craneNotdefault = false;
        }
        else
        {
            craneNotdefault = true;
           
        }

    }
    

    
}
