using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabinWoodSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    QuestManager questManager;
    public GameObject wood;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        wood.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.acceptFirstQuest)
        {
            wood.SetActive(false);
        }
    }
}
