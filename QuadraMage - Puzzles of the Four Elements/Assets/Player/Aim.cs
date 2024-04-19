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

    public float shootPointOffsetLY;
    public float shootPointOffsetLX;

    public float shootPointOffSetRY;
    public float shootPointOffSetRX;


    public GameObject shootPoint;

    
    NewPauseMenu newPauseMenu;
    Inventory inventory;
    

    public float maxZRot = 15;
    public float minZRot = -40;

    public float maxZRotL = 360;
    public float minZRotL = 0;

    private Transform localTrans;





    private void Start()
    {
        localTrans = GetComponent<Transform>();
    }


    void Update()
    {
        if (!NewPauseMenu.isPauseMenuOpen && !MovingPlatform.isChildOfPlatform && PlayerMovement.isInputEnabled == true)
        {
            if (!Inventory.isPlayerUsingElement)
            {
                // Gun Rotation Function
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

                // Check if the player is facing right or left
                if (PlayerMovement.playerFacingRight)
                {
                    sprite.flipY = false;
                    //Wand.transform.localScale = new Vector2 (0.7563f, 0.7563f);
                    Wand.transform.localPosition = new Vector2(offsetRightX, offsetRightY);
                    shootPoint.transform.localPosition = new Vector2(shootPointOffSetRX, shootPointOffSetRY);

                    // Limit the rotation for right-facing direction
                    //rotZ = Mathf.Clamp(rotZ, minZRot, maxZRot);
                }
                else
                {
                    sprite.flipY = true;
                    //Wand.transform.localScale = new Vector2(-0.7563f, 0.7563f);
                    Wand.transform.localPosition = new Vector2(offsetLeftX, offsetLeftY);
                    shootPoint.transform.localPosition = new Vector2(shootPointOffsetLX, shootPointOffsetLY);

                    // Limit the rotation for left-facing direction
                    //rotZ = Mathf.Clamp(rotZ, minZRotL, maxZRotL);
                }

                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            }
        }
    }


    public void LimitRot()
    {

        Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;
        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);
        localTrans.rotation = Quaternion.Euler(playerEulerAngles);



    }


}




