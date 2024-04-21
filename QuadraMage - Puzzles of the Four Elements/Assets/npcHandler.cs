using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHandler : MonoBehaviour
{
   

    QuestManager questManager;
  
    void Start()
    {
      
        questManager = FindObjectOfType<QuestManager>();
        Debug.Log("Quest Manager found: " + (questManager != null));
    }

   
    void Update()
    {
      
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            
            questManager.NPCQuest2.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
           if (questManager.getQuestNumber == 1 )
            {

                
                questManager.setVisibleNPC1();
            }
            if (questManager.getQuestNumber == 2)
            {
               
                questManager.setVisibleNPC2();
            }

            if (questManager.getQuestNumber == 3)
            {
               
                questManager.setVisibleNPC3();
            }

        }

        






    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (questManager.getQuestNumber == 1)
            {
              
                questManager.setInVisibleNPC1();
            }
            if (questManager.getQuestNumber == 2)
            {
              
                questManager.setInVisibleNPC2();
            }
            if (questManager.getQuestNumber == 3)
            {
               
                questManager.setInVisibleNPC3();
            }

        }
    }

   
}
