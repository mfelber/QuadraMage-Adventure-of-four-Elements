using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnQuest1Items : MonoBehaviour
{
    private QuestManager questManager;
    //[SerializeField] GameObject box;
    public int removeItem;

   [SerializeField] private List<GameObject> questItems = new List<GameObject>();
    
    
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        //box.SetActive(false);
        for (int i = 0; i < questItems.Count; i++)
        {
            questItems[i].SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
        if(questManager.acceptFirstQuest == true)
        {
            for (int i = 0; i < questItems.Count; i++)
            {
                questItems[i].SetActive(true);
            }
            questItems.RemoveAt(removeItem);
        }
        
       



    }
}
