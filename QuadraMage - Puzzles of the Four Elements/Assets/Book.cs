using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Book : MonoBehaviour
{
    public GameObject book;
    
    public static bool isBookOpen;


    void Start()
    {
        book.SetActive(false);
        
    }

    void Update()
    {
        if (!NewPauseMenu.isPauseMenuOpen )
        {
            if (Input.GetKeyUp(KeyCode.B))
            {
                if (isBookOpen)
                {
                    OpenBook();
                }
                else
                {
                    CloseBook();
                }
            }
        }
       
    }

    public void CloseBook()
    {
        book.SetActive(true);
        Time.timeScale = 0f;
        isBookOpen = true;
        
    }

    public void OpenBook()
    {
        book.SetActive(false);
        Time.timeScale = 1f;
        isBookOpen = false;       

    }
}
