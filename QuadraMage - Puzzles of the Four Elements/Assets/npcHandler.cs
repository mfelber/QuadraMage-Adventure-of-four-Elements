using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHandler : MonoBehaviour
{
    // Start is called before the first frame update

    QuestManager questManager;
   // public bool isHided;
    void Start()
    {
       //isHided = false;
        questManager = FindObjectOfType<QuestManager>();
        Debug.Log("Quest Manager found: " + (questManager != null));
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isHided);
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            //questManager.NPCQuest1.SetActive(false);
            questManager.NPCQuest2.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
           if (questManager.getQuestNumber == 1 )
            {

                //Debug.Log(questManager.isQuest1comp);
                questManager.setVisibleNPC1();
            }
            if (questManager.getQuestNumber == 2)
            {
                //Debug.Log(questManager.isQuest1comp);
                questManager.setVisibleNPC2();
            }

            if (questManager.getQuestNumber == 3)
            {
                //Debug.Log(questManager.isQuest1comp);
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
                //Debug.Log(questManager.isQuest1comp);
                questManager.setInVisibleNPC1();
            }
            if (questManager.getQuestNumber == 2)
            {
                //Debug.Log(questManager.isQuest1comp);
                questManager.setInVisibleNPC2();
            }
            if (questManager.getQuestNumber == 3)
            {
                //Debug.Log(questManager.isQuest1comp);
                questManager.setInVisibleNPC3();
            }

        }
    }

    /*
    public bool IsHided
    {
        get { return isHided;}
    }
    */
}
