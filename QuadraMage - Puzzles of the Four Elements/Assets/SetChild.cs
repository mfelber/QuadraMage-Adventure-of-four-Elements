using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChild : MonoBehaviour
{
    public bool isChild;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            
            collision.transform.SetParent(transform);
           if(collision.transform.parent == transform)
            {
                Debug.LogError("je child");
                isChild = true;
            } 
           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box") )
        {
           
            collision.transform.SetParent(null);
            if (collision.transform.parent != transform)
            {
                Debug.LogError("nie child");
                isChild = false;
            }
            

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError(isChild);
    }
}
