using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    public float speed;
    public bool isRightFacing;

    void Start()
    {
        if (speed <= 0)
        {
            Debug.LogError("You forgot to set the spped tp non-zero");
        }
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
}
