using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnQuest2Items : MonoBehaviour
{
    private QuestManager questManager;
    private PoseidonQuestManager poseidonQuestManager;
    //[SerializeField] GameObject box;

    [SerializeField] private List<GameObject> questItems = new List<GameObject>();
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
        //box.SetActive(false);
        for (int i = 0; i < questItems.Count; i++)
        {
            questItems[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.acceptSecondQuest == true)
        {
            for (int i = 0; i < questItems.Count; i++)
            {
                questItems[i].SetActive(true);
            }
        }

        if (poseidonQuestManager.poseidonMarmaidQuestCom == true)
        {
            for (int i = 0; i < questItems.Count; i++)
            {
                questItems[i].SetActive(false);
            }
        }


    }
}
