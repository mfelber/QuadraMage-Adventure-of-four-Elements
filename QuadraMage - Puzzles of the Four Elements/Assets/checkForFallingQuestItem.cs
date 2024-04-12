using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkForFallingQuestItem : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Iron"))
            {
                collision.transform.position = new Vector2(5.308025f, 23.71198f);
                item.text = "iron padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

        if (rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Wood"))
            {
                collision.transform.position = new Vector2(31.65f, 23.83f);
                item.text = "wood padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

        if (rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Gold"))
            {
                collision.transform.position = new Vector2(-94.14f, 12f);
                item.text = "gold padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

        if (leftPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Iron"))
            {
                collision.transform.position = new Vector2(5.308025f, 23.71198f);
                item.text = "iron padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

        if (leftPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Wood"))
            {
                collision.transform.position = new Vector2(31.65f, 23.83f);
                item.text = "wood padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

        if (leftPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Gold"))
            {
                collision.transform.position = new Vector2(-94.14f, 12f);
                item.text = "gold padol chod si pre neho";
                animator.Play("itemFall");
                Invoke("hideWarning", 2f);
            }
        }

       
    }
    public void hideWarning()
    {
        animator.Play("itemFallHide");
    }

}
