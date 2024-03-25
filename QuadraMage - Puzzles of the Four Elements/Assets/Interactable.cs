using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public  bool inRange;
    public KeyCode interactKey;
    public UnityEvent interact;
    public GameObject interactionMassage;
    void Start()
    {
        interactionMassage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (inRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interact.Invoke();
            }
        }

        //Debug.LogError(inRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            inRange = true;
            interactionMassage.SetActive(true);
            //Debug.Log("In range");
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            interactionMassage.SetActive(false);
            //Debug.Log("Not In range");
        }
        
    }
}
