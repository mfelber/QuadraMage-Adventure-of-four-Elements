using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthScript : MonoBehaviour
{
    public float speed;
    public bool isRightFacing;
    void Start()
    {
        
       
    }
    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
       
    }
}