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

    PauseMenu pauseMenu;


    void Update()
    {
        if (!PauseMenu.isGamePaused)
        {

            // Gun Rotation Function
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;


            if (rotZ < 89 && rotZ > -89)
            {

                sprite.flipY = false;
                Wand.transform.localPosition = new Vector2(offsetRightX, offsetRightY);
                shootPoint.transform.localPosition = new Vector2(shootPointOffSetRightX, shootPointOffSetRightY);
                // Wand.transform.localPosition = Vector2.zero;

            }
            else
            {

                sprite.flipY = true;
                //Vector2 pos = new Vector2(transform.position.x, transform.position.y + offset);
                //transform.position = pos;
                Wand.transform.localPosition = new Vector2(offsetLeftX, offsetLeftY);
                shootPoint.transform.localPosition = new Vector2(shootPointOffsetLeftX, shootPointOffsetLeftY);


            }

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
    }

}




