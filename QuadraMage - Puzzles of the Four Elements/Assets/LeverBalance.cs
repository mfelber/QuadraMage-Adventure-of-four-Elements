using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBalance : MonoBehaviour
{
    public static bool isLeverOn;
    public GameObject arrow;
    public GameObject LeverOff, LeverOn;

    void Start()
    {
        arrow.SetActive(true);
        LeverOn.SetActive(true);
        LeverOff.SetActive(false);
        isLeverOn = true;
        Invoke("DeactivateLever", 2.2f);

        //GetComponent<SpriteRenderer>().sprite = on;  
        
    }

   
    void Update()
    {
        if (Player.inRangeOfLever && Input.GetKeyDown(KeyCode.E) && isLeverOn == false)
        {
            ActivateLever();
        }

        if (isLeverOn == true)
        {
            arrow.SetActive(false);
            LeverOn.SetActive(true);
            LeverOff.SetActive(false);
        } else
        {
            arrow.SetActive(true);
            LeverOn.SetActive(false);
            LeverOff.SetActive(true);

        }

      
        if (PlayerMovement.isInputEnabled == false)
        {
            Invoke("enableInput", 1.9f);
        }
        
        
        Debug.LogError(isLeverOn);
        
    }

    public void enableInput()
    {
        PlayerMovement.isInputEnabled = true;
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
        LeverOn.SetActive(true);
        LeverOff.SetActive(false);
        //GetComponent<SpriteRenderer>().sprite = on;
        Invoke("DeactivateLever", 2.2f);
    }



    private void DeactivateLever()
    {
        //GetComponent<SpriteRenderer>().sprite = off;

        
        StartCoroutine(leverisActive());
    }



    IEnumerator leverisActive()
    {
        
        yield return new WaitForSeconds(2f);
        isLeverOn = false;
        LeverOn.SetActive(false);
        LeverOff.SetActive(true);
        // GetComponent<SpriteRenderer>().sprite = leverOff;
    }


}
