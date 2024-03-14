using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSecondNpc : MonoBehaviour
{
    [SerializeField] private GameObject Npc;
    [SerializeField] private GameObject NpcQuest1;
    [SerializeField] private GameObject NpcQuest1Thanks;
    private QuestManager questManager;
    private PoseidonQuestManager poseidonQuestManager;
    private int presiel;
    void Start()
    {
        Npc.SetActive(true);
        NpcQuest1.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           

            if (questManager.getQuestNumber == 2)
            {
                
                NpcQuest1.SetActive(true);
                Npc.SetActive(false);
                questManager.NPCQuest2.SetActive(false);

            } else
            {
                Npc.SetActive(true);
            }

            if (poseidonQuestManager.poseidonMarmaidQuestCom == true)
            {
                NpcQuest1Thanks.SetActive(true);
                NpcQuest1.SetActive(false);
            }

        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (questManager.getQuestNumber == 2)
            {

                NpcQuest1.SetActive(false);
                //Poseidon.SetActive(false);
                //questManager.NPCQuest2.SetActive(true);

            }
            else
            {
                Npc.SetActive(false);
            }

            if (poseidonQuestManager.poseidonMarmaidQuestCom == true)
            {

                NpcQuest1Thanks.SetActive(false);
            } 

        }
    }
}
