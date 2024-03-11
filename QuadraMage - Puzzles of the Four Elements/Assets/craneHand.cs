using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneHand : MonoBehaviour
{

    private bool craneNotdefault;
    public Animator craneHandAnimator;
    
    public Rigidbody2D rop1;
    //public GameObject rope1;
    public Rigidbody2D rop2;
    public Rigidbody2D rop3;
    public Rigidbody2D tntBox;
    
    void Start()
    {
        craneNotdefault = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WindElementShot"))
        {
            Debug.Log("kolizia");
            if(craneNotdefault == true)
            {
                rop1.bodyType = RigidbodyType2D.Static;
                rop2.bodyType = RigidbodyType2D.Static;
                rop3.bodyType = RigidbodyType2D.Static;    
                tntBox.bodyType = RigidbodyType2D.Static;
                //rope1.transform.position = new Vector3(rope1.transform.position.x, rope1.transform.position.y, 0);
                StopAllCoroutines();

                StartCoroutine(setRotateBool());
                craneHandAnimator.SetBool("rotate", true);
                //Invoke("setRotateBool", 2.5f);

                
               
                //craneNotdefault = false;
            }
            
        }

        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            if(craneNotdefault == false)
            {
                rop1.bodyType = RigidbodyType2D.Static;
                rop2.bodyType = RigidbodyType2D.Static;
                rop3.bodyType = RigidbodyType2D.Static;
                tntBox.bodyType = RigidbodyType2D.Static;
                //Invoke("setRotateBool", 2.5f);
                StopAllCoroutines();
                StartCoroutine(setRotateBool());
                craneHandAnimator.SetBool("rotate", false);
            }
           
        }
    }
    
    IEnumerator setRotateBool()
    {
        yield return new WaitForSeconds(2.5f);

        if (craneNotdefault == true)
        {
            rop1.bodyType = RigidbodyType2D.Dynamic;
            rop2.bodyType = RigidbodyType2D.Dynamic;
            rop3.bodyType = RigidbodyType2D.Dynamic;
            tntBox.bodyType = RigidbodyType2D.Dynamic;
            craneNotdefault = false;
        }
        else
        {
            craneNotdefault = true;
            rop1.bodyType = RigidbodyType2D.Dynamic;
            rop2.bodyType = RigidbodyType2D.Dynamic;
            rop3.bodyType = RigidbodyType2D.Dynamic;
            tntBox.bodyType = RigidbodyType2D.Dynamic;
        }

    }
    

    /*
    public void setRotateBool ()
    {
        if (craneNotdefault == true)
        {
            craneNotdefault = false;
            rop1.bodyType = RigidbodyType2D.Dynamic;
            rop2.bodyType = RigidbodyType2D.Dynamic;
            rop3.bodyType = RigidbodyType2D.Dynamic;
            tntBox.bodyType = RigidbodyType2D.Dynamic;
        } else
        {
            craneNotdefault = true;
            rop1.bodyType = RigidbodyType2D.Dynamic;
            rop2.bodyType = RigidbodyType2D.Dynamic;
            rop3.bodyType = RigidbodyType2D.Dynamic;
            tntBox.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    */
}
