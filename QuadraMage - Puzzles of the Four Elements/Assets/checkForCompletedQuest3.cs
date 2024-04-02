using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkForCompletedQuest3 : MonoBehaviour
{
    private QuestManager questManager;
    public GameObject completedQ3, notCompletedQ3, lever, leverBlock, leverBlock2;
    public Animator woodLogAnimator;

    // Start is called before the first frame update
    void Start()
    {
        notCompletedQ3.SetActive(false);
             
        completedQ3.SetActive(false);
        lever.SetActive(false);
        leverBlock.SetActive(false);
        leverBlock2.SetActive(false);
        questManager = FindObjectOfType<QuestManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.isQuest3comp == true)
        {
           
            if (Player.inRangeOfNPC && Input.GetKeyDown(KeyCode.E))
            {
                
                lever.SetActive(true);
                woodLogAnimator.Play("woodLogLeverDownLevel2");
            }
        }

        if(DialogManager.isDialgueActive)
        {
            leverBlock.SetActive(true);
            leverBlock2.SetActive(true);
        } else
        {
            leverBlock.SetActive(false);
            leverBlock2.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (questManager.isQuest3comp == true)
            {
                notCompletedQ3.SetActive(false);
                completedQ3.SetActive(true);
            }
            else
            {
                notCompletedQ3.SetActive(true);
                completedQ3.SetActive(false);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            notCompletedQ3.SetActive(false);
            completedQ3.SetActive(false);
        }
    }
}
