using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverRoundedRocksScript : MonoBehaviour
{
    public GameObject off, on, destoyed;
    public static bool isLeverOn;
    public GameObject arrow;
    public bool leverDestoyed;
    void Start()
    {
        off.SetActive(true);
        on.SetActive(false);
        isLeverOn = false;
        leverDestoyed = false;
       // Invoke("DeactivateLever", 2.2f);
        arrow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (leverDestoyed == false)
        {
            if (Player.inRangeOfLever && Input.GetKeyDown(KeyCode.E))
            {
                ActivateLever();
            }
           
        } else
        {
            DeactivateLever();
        }

        
        
            if (isLeverOn == true)
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);            
            }

            
            
        if (leverDestoyed == true)
        {

           arrow.SetActive(false);
            off.SetActive(false);
            on.SetActive(true);
            // Destroy(arrow);
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WindElementShot"))
        {
            //Debug.LogError("kolizia");
            ActivateLever();
        }

        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("kolizia kamen packa");
            leverDestoyed = true;

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
        off.SetActive(false);
        on.SetActive(true);
        Invoke("DeactivateLever", 2.2f);
    }

    private void DeactivateLever()
    {
        off.SetActive(true);
        on.SetActive(false);
        isLeverOn = false;
    }
}
