using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    // Start is called before the first frame update
   public  GameObject Player;
    public CinemachineVirtualCamera cinemachine;
    

    public static bool isPlayerHide;
    public bool inRange;

    

    void Start()
    {
       isPlayerHide = false;
       cinemachine = GetComponent<CinemachineVirtualCamera>();
        
       
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {

            if (!isPlayerHide)
            {                             
                hidePlayer();
            }



        }
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerHide)
            {
                unHidePlayer();
            }
        }


        if (isPlayerHide)
        {
            inRange = true;
            cinemachine.enabled = false;
        } else
        {
            cinemachine.enabled = true;
        }
        
      
        
        Debug.LogError(inRange);
        Debug.LogError(isPlayerHide);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;  
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }


    public void hidePlayer()
    {

        isPlayerHide = true;
        Player.transform.position = new Vector2(13.4f, 213.9617f);
        
        //Player.SetActive(false);

        //LeftFoot.SetActive(false);
        //RightFoot.SetActive(false);


    }

    public void hide()
    {
        
    }

   

    public void unHidePlayer()
    {
                
      
           Player.SetActive(true);
            //LeftFoot.SetActive(true);
            //RightFoot.SetActive(true);
            isPlayerHide = false;
        
        
    }


}
