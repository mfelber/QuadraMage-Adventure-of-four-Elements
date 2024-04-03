using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnQuest2Items : MonoBehaviour
{
    private QuestManager questManager;
    private PoseidonQuestManager poseidonQuestManager;
    //[SerializeField] GameObject box;
    public int removeItem;

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

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

    
            if (questManager.acceptSecondQuest == true)
            {
                if (questItems.Count > 0)
                {
                    for (int i = 0; i < questItems.Count; i++)
                    {
                        questItems[i].SetActive(true);

                    }
                    questItems.RemoveAt(removeItem);
                }
            }
        



        if(sceneName == "Level 3")
        {
            if (poseidonQuestManager.poseidonMarmaidQuestCom == true)
            {
                for (int i = 0; i < questItems.Count; i++)
                {
                    questItems[i].SetActive(false);
                }
            }
        }
        


    }
}
