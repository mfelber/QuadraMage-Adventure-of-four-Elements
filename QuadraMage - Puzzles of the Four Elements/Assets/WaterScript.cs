using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public float speed;
    public bool isrightFacing;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        if (speed == 0)
        {
            Debug.LogError("Speed is set to 0");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isrightFacing)
        {
         
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }

          
            if (spriteRenderer.flipY == true)
            {
                spriteRenderer.flipY = false;
            }

           
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {

            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }

            if (spriteRenderer.flipY == false)
            {
                spriteRenderer.flipY = true;
            }

        
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
}