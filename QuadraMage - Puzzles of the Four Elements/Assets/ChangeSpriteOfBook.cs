using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOfBook : MonoBehaviour
{
    public Sprite closedBook, OpenedBook;
    
    Book book;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = closedBook;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Book.isBookOpen)
        {
            GetComponent<SpriteRenderer>().sprite = closedBook;
        } else
        {            
            GetComponent<SpriteRenderer>().sprite = OpenedBook;
        }
        
        
    }
}
