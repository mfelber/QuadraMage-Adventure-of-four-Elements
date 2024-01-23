using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteOfBook : MonoBehaviour
{
    public Sprite closedBook, OpenedBook;
    public GameObject bookSprite;
    
    Book book;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = closedBook;
        book = GetComponent<Book>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Book.isBookOpen)
        {
            GetComponent<SpriteRenderer>().sprite = closedBook;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else
        {     
            
            GetComponent<SpriteRenderer>().sprite = closedBook;
            transform.rotation = Quaternion.Euler(0f, 0f, -11.3f);
        }
        
        
    }
}
