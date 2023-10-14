using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Aim : MonoBehaviour
{
    //public Transform Wand;
    Vector2 direction;

    public GameObject Player;
    public GameObject Wand;
    public float turnSpeed = 45f;
   
   

    public SpriteRenderer sprite;


    public float offsetRightX;
    public float offsetRightY;

    public float offsetLeftX;
    public float offsetLeftY;

    public float shootPointOffsetLeftY;
    public float shootPointOffsetLeftX;

    public float shootPointOffSetRightY;
    public float shootPointOffSetRightX;


    public GameObject shootPoint;


    

    void Update()
    {
        // Gun Rotation Function
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


        if (rotZ < 89 && rotZ > -89)
        {
            Debug.Log("Facing right");
            sprite.flipY = false;
            Wand.transform.localPosition = new Vector2(offsetRightX, offsetRightY);
            shootPoint.transform.localPosition = new Vector2(shootPointOffSetRightX, shootPointOffSetRightY);
            // Wand.transform.localPosition = Vector2.zero;

        }
        else
        {
            Debug.Log("Facing left");
            sprite.flipY = true;
            //Vector2 pos = new Vector2(transform.position.x, transform.position.y + offset);
            //transform.position = pos;
            Wand.transform.localPosition = new Vector2(offsetLeftX, offsetLeftY);
            shootPoint.transform.localPosition = new Vector2(shootPointOffsetLeftX, shootPointOffsetLeftY);
            

        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }

    /*
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        
        if (Player.transform.eulerAngles.y == 180 && k)
        {
            angle += 180;
            k = false;
        }

        targetRotation = new Vector3(angle, 0, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);

       

    }
    */

    /*
    private void FixedUpdate()
{
    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    difference.Normalize();

    float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    transform.rotation = Quaternion.Euler(0f,0f,rotationZ);


    if (rotationZ < -90 || rotationZ > 90)
    {
        if (Player.transform.eulerAngles.y == 0)
        {
            transform.localRotation = Quaternion.Euler(180, 0f, -rotationZ);

        }
        else if (Player.transform.eulerAngles.y == 180)
        {
            transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
        }


    } 
    */


    void faceMouse()
    {
        Wand.transform.right = direction;
    }
}






    /*
    void Update()
    {

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - (Vector2)Wand.transform.position;
        direction.Normalize();
        Vector2 pos = new Vector2(direction.x * Player.transform.right.x, direction.y * Player.transform.right.y);
        Wand.transform.LookAt(direction,Player.transform.right);
      //  faceMouse();


    
}
    */




