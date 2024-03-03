using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBalance : MonoBehaviour
{
    public Sprite off, on;
    public static bool isLeverOn;
    public GameObject arrow;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = on;  
        isLeverOn = true;
        Invoke("DeactivateLever", 2.2f);
        arrow.SetActive(true);
    }

   
    void Update()
    {
        if (Player.inRangeOfLever && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();
        }

        if (isLeverOn == true)
        {
            arrow.SetActive(false);
        } else
        {
            arrow.SetActive(true);

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            //Debug.LogError("kolizia");
            ActivateLever();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            Invoke("DeactivateLever", 2.2f);
        }
    }

    private void ActivateLever()
    {
        isLeverOn = true;
        GetComponent<SpriteRenderer>().sprite = on;
        Invoke("DeactivateLever", 2.2f);
    }

    private void DeactivateLever()
    {
        GetComponent<SpriteRenderer>().sprite = off;
        isLeverOn = false;
    }
}
