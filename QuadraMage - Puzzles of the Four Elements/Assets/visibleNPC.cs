using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibleNPC : MonoBehaviour
{
    // Start is called before the first frame update

    QuestManager questManager;
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(questManager.isNpc1Vis);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Player"))
        {
            if(questManager.npc1Vis == true)
            {
                questManager.setVisibleNPC1();
            }
            else if (questManager.npc2Vis )
            {
                questManager.setVisibleNPC2();
            }




        }
        */
        
    }
}
