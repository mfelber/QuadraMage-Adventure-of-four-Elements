using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForFallingQuestItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject iron;
    RightPlatform rightPlatform;
    void Start()
    {
        rightPlatform = FindObjectOfType<RightPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Iron"))
            {
                collision.transform.position = new Vector2(5.308025f, 23.71198f);
            }
        }

        if (rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Wood"))
            {
                collision.transform.position = new Vector2(31.65f, 23.83f);
            }
        }

        if (rightPlatform.boxOnPlatform == false)
        {
            if (collision.gameObject.CompareTag("Gold"))
            {
                collision.transform.position = new Vector2(-94.14f, 12f);
            }
        }

    }
}
