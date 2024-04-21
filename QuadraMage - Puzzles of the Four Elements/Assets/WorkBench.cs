using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour
{

    Player player;
    QuestManager questManager;


    

    private void Start()
    {
        player = GetComponent<Player>();
        questManager = FindObjectOfType<QuestManager>();
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Gold"))
            {
                questManager.quest1Completed();         
            
            
            
        }
        

       
            if (collision.gameObject.CompareTag("Iron"))
            {
                questManager.quest2Completed();
            
        }

       
            if (collision.gameObject.CompareTag("Wood"))
            {
                questManager.quest3Completed();
           
        }

            if (collision.gameObject.CompareTag("GunPowder"))
        {
            questManager.quest1Completed();
           
        }

       


    }

    
}
