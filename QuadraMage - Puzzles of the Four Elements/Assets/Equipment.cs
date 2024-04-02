using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public  bool isPlayerMoveEquipmentWithWind;
    public  bool isPlayerMoveEquipment;
    public bool eqfall;
    public Animator eqAnimator;
    QuestManager questManager;
    public GameObject equipment, empty;



    void Start()
    {
        isPlayerMoveEquipmentWithWind = false;
        isPlayerMoveEquipment = false;
        eqfall = false;
        questManager = FindObjectOfType<QuestManager>();
        equipment.SetActive(true);
        empty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {            
            isPlayerMoveEquipment = true;
            Invoke("stop", 2);
        }
       

        if (questManager.acceptSecondQuest)
        {
            if (collision.gameObject.CompareTag("WindElementShot"))
            {

                isPlayerMoveEquipmentWithWind = true;
                
                eqAnimator.Play("EquipmentFall");
                equipment.SetActive(false);
                empty.SetActive(true);
                Invoke("stop", 2);
            }
        }
        

    }

    public void stop () {
        isPlayerMoveEquipmentWithWind = false;
        isPlayerMoveEquipment = false;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        /*
        if (collision.gameObject.CompareTag("WindElementShot"))
        {

            isPlayerMoveWithArmorStand = false;
        }
        */
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           

            isPlayerMoveWithArmorStand = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerMoveWithArmorStand = false;
        }
    }

    */
}
