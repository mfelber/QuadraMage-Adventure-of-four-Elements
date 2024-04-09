using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flintAndSteel : MonoBehaviour
{
    public GameObject flintandSteel;
    QuestManager questManager;
    void Start()
    {
        flintandSteel.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(questManager.acceptFirstQuest)
        {
            flintandSteel.SetActive(true);
        }

       
    }
}
