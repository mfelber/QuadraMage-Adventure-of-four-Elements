using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBalance : MonoBehaviour
{
    public Sprite off, on;
    public static bool isLeverOn;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = on;  
        isLeverOn = true;
        Invoke("DeactivateLever", 2.2f);  
    }

   
    void Update()
    {
        if (Player.inRangeOfLever && Input.GetKeyDown(KeyCode.E))
        {
            ActivateLever();
        }
        Debug.LogError(isLeverOn);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            Debug.LogError("kolizia");
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
