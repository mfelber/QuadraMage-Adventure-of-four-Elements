using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseidonCage : MonoBehaviour
{
    // Start is called before the first frame update
    QuestManager questManager;
    public List<GameObject> itemsToSpawn = new List<GameObject>();
    bool pirateIsFree;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        pirateIsFree = false;

        for (int i = 0; i < itemsToSpawn.Count; i++)
        {
            itemsToSpawn[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pirateIsFree)
        {
            for (int i = 0; i < itemsToSpawn.Count; i++)
            {
                itemsToSpawn[i].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterElementShot"))
        {
            questManager.quest3Completed();
            pirateIsFree = true;
            //Destroy(collision.gameObject);
        }
    }
}
