using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseElement : MonoBehaviour
{

    
    public GameObject Fire;
    public float fireSpeed;
    //public Transform aimPoint;


    
    //Vector2 direction;
    MouseMovementRestriction skriptB;
    
    
    void Start()
    {
        GameObject objektSakriptomB = GameObject.Find("Player");
        skriptB = objektSakriptomB.GetComponent<MouseMovementRestriction>();

    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // getting mouse position
        //direction = mousePosition - (Vector2)Element.position;
        //aim();

        skriptB.aim();
        if (Input.GetMouseButtonDown(0))
        {
            fire();
            
            Debug.Log("Strielam");
        }
    }

    /*void aim()
    {
        Element.transform.right = direction;
    }
*/
    void fire()
    {
       
        GameObject fireInstance = Instantiate(Fire, skriptB.aimPoint.position, skriptB.aimPoint.rotation);
        fireInstance.GetComponent<Rigidbody2D>().AddForce(fireInstance.transform.right * fireSpeed);
        Destroy(fireInstance,1); // destroy fire instance after 2 second when player use element
                                 // 
        
    }
}
