using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public float speed;
    public bool isRightFacing;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Elements"), LayerMask.NameToLayer("Ship"), true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRightFacing)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        } else
        {
            SpriteRenderer wind = GetComponent<SpriteRenderer>();
            if(wind.flipX == false)
                wind.flipX = true;
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    */
}
