using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    Player player;
    QuestManager questManager;


    //public GameObject Gold;
    /*
    public GameObject Iron;

    public GameObject Wood;
    */

    private void Start()
    {
        player = GetComponent<Player>();
        questManager = FindObjectOfType<QuestManager>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Block"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Enemy"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("Fluids"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("item"), LayerMask.NameToLayer("WaterTank"));
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Gold"))
            {
                questManager.quest1Completed();         
            
             //  Gold.SetActive(false);
            
        }
        

       
            if (collision.gameObject.CompareTag("Iron"))
            {
                questManager.quest2Completed();
            //Destroy(collision.gameObject);
            //Iron.SetActive(false);

        }

       
            if (collision.gameObject.CompareTag("Wood"))
            {
                questManager.quest3Completed();
           // Destroy(collision.gameObject);
            //Wood.SetActive(false);
        }

            if (collision.gameObject.CompareTag("GunPowder"))
        {
            questManager.quest1Completed();
            //Destroy(collision.gameObject);
        }


    }

    
}
