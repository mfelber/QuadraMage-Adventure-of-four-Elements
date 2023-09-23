using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private Elements elements;
    public GameObject element;
    // Start is called before the first frame update
    void Start()
    {
        elements = GameObject.FindGameObjectWithTag("Player").GetComponent<Elements>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < elements.slots.Length; i++)
            {
                if (elements.isFull[i] == false)
                {
                    elements.isFull[i] = true;
                    Instantiate(element, elements.slots[i].transform,false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
