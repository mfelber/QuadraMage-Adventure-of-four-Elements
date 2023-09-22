using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class MouseMovementRestriction : MonoBehaviour
{

    

    public Transform aimPoint;
    Vector2 direction;
    public Transform Wand;

    PlayerMovement skript;


    

    void Start()
    {
        GameObject objektSakriptomB = GameObject.Find("Player");
        skript = objektSakriptomB.GetComponent<PlayerMovement>();
    }


    void Update()
    {
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // getting mouse position
         direction = mousePosition - (Vector2)Wand.position;

       
        
    }



  

     public void aim()
    {
        Wand.transform.right = direction;
    }

}
