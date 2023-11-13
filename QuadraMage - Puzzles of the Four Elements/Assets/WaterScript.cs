using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public float speed;
    public bool isrightFacing;

    void Start()
    {
        if (speed == 0)
        {
            Debug.LogError("Speed is set to 0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isrightFacing) 
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        else
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite.flipX == false) sprite.flipX = true;
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
}
