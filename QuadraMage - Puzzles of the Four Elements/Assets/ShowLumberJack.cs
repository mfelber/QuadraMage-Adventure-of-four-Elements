using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLumberJack : MonoBehaviour
{
    [SerializeField] private GameObject Npc;
    [SerializeField] private GameObject NpcQuest1;
    
    private QuestManager questManager;
    void Start()
    {
        Npc.SetActive(true);
        NpcQuest1.SetActive(false);
       
        questManager = FindObjectOfType<QuestManager>();
        


    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            if (questManager.acceptThirdQuest)
            {

                NpcQuest1.SetActive(true);
                Npc.SetActive(false);
                

            }
            else
            {
                Npc.SetActive(true);
            }

            

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (questManager.acceptThirdQuest)
            {

                NpcQuest1.SetActive(false);
                

            }
            else
            {
                Npc.SetActive(false);
            }

            

        }
    }
}
