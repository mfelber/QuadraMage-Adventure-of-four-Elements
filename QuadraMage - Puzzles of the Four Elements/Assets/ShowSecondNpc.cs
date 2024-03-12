using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSecondNpc : MonoBehaviour
{
    [SerializeField] private GameObject Npc;
    [SerializeField] private GameObject NpcQuest;
    private QuestManager questManager;
    private int presiel;
    void Start()
    {
        Npc.SetActive(true);
        NpcQuest.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        presiel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(questManager.getQuestNumber == 2)
            {
                
                NpcQuest.SetActive(true);
                Npc.SetActive(false);
                questManager.NPCQuest2.SetActive(false);

            } else
            {
                Npc.SetActive(true);
            }
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (questManager.getQuestNumber == 2)
            {

                NpcQuest.SetActive(false);
                //Poseidon.SetActive(false);
                //questManager.NPCQuest2.SetActive(true);

            }
            else
            {
                Npc.SetActive(false);
            }


        }
    }
}
