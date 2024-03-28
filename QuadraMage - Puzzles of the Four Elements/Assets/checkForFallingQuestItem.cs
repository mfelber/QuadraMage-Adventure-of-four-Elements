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
                collision.transform.position = new Vector2(43.2f, 67.8f);
            }
        }
        
    }
}
