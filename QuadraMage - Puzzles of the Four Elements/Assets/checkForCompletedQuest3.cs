using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForCompletedQuest3 : MonoBehaviour
{
    private QuestManager questManager;
    public GameObject completedQ3, notCompletedQ3, lever;
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        notCompletedQ3.SetActive(true);
        completedQ3.SetActive(false);
        lever.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.isQuest3comp == true)
        {
            notCompletedQ3.SetActive(false);
            completedQ3.SetActive(true);
            lever.SetActive(true);
        }
    }
}
