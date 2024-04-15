using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class WaterScript : MonoBehaviour
{
    public float speed;
    public bool isrightFacing;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Cage"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Ship"), true);

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

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Cloud"))
        {

            Destroy(gameObject);
        }

    }
    */

}
