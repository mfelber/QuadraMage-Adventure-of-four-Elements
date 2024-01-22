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

    PauseMenu pauseMenu;
    Inventory inventory;
    Book book;

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
        if (!PauseMenu.isGamePaused && !Book.isBookOpen)
        {
            if (!Inventory.isPlayerUsingElement) { 
                // Gun Rotation Function
                Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;



            if (rotZ < 89 && rotZ > -89)
            {

                sprite.flipY = false;

                Wand.transform.localPosition = new Vector2(offsetRightX, offsetRightY);
                shootPoint.transform.localPosition = new Vector2(shootPointOffSetRX, shootPointOffSetRY);
                // Wand.transform.localPosition = Vector2.zero;
                //  rotZ = Mathf.Clamp(rotZ, minZRot, maxZRot);

                /*

                Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;
                playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
                playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRot, maxZRot);
                localTrans.rotation = Quaternion.Euler(playerEulerAngles);

                */
            }
            else
            {

                sprite.flipY = true;

                //Vector2 pos = new Vector2(transform.position.x, transform.position.y + offset);
                //transform.position = pos;
                Wand.transform.localPosition = new Vector2(offsetLeftX, offsetLeftY);
                shootPoint.transform.localPosition = new Vector2(shootPointOffsetLX, shootPointOffsetLY);
                //  rotZ = Mathf.Clamp(rotZ, minZRotL, maxZRotL);
                /*
                Vector3 playerEulerAngles = localTrans.rotation.eulerAngles;
                playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
                playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minZRotL, maxZRotL);
                localTrans.rotation = Quaternion.Euler(playerEulerAngles);
                */

            }

            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            // LimitRot();
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




