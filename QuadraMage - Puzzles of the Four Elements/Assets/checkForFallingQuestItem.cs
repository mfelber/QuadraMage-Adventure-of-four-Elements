using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkForFallingQuestItem : MonoBehaviour
{
   
    public GameObject iron;
    RightPlatform rightPlatform;
    Lava leftPlatform;
    public TextMeshProUGUI item;
    public Animator animator;   

    void Start()
    {
        rightPlatform = FindObjectOfType<RightPlatform>();
        leftPlatform = FindObjectOfType<Lava>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      /*
            if (collision.gameObject.CompareTag("Iron") && RightPlatform.boxOnPlatform == false)
            {         
            
                collision.transform.position = new Vector2(5.308025f, 23.71198f);
                item.text = "iron padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            
        } else
        {
            return;
        }
      */
             if (RightPlatform.boxOnPlatform == false && Lava.boxOnPlatform == false)
            {

            if (collision.gameObject.CompareTag("Iron"))
            {

                collision.transform.position = new Vector2(5.308025f, 23.71198f);
                item.text = "Iron has fallen, go back and get it";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);

            }

            if (collision.gameObject.CompareTag("Wood"))
            {
                collision.transform.position = new Vector2(36.9f, 23.83f);
                item.text = "Wood has fallen, go back and get it";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }

            if (collision.gameObject.CompareTag("Gold") )
            {
                collision.transform.position = new Vector2(-94.14f, 12f);
                item.text = "Gold has fallen, go back and get it";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);

            }
            
        } 
                    
             /*
        if (Lava.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Iron"))
            {
                collision.transform.position = new Vector2(5.308025f, 23.71198f);
                item.text = "iron padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }

            if (collision.gameObject.CompareTag("Wood"))
            {
                collision.transform.position = new Vector2(36.9f, 23.83f);
                item.text = "wood padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
            if (collision.gameObject.CompareTag("Gold"))
            {
                collision.transform.position = new Vector2(-94.14f, 12f);
                item.text = "gold padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        } else
        {
            return;
        }

       */

       
    }


    
    
    public void hideWarning()
    {
        animator.Play("itemFallHide");
    }

}
