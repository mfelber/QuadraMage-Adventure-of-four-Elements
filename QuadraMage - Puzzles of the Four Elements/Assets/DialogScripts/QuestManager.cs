using System.Collections.Generic;
using UnityEngine;



public class QuestManager : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();


    public GameObject NPCQuest1;
    public GameObject NPCQuest2;
    public GameObject NPCQuest3;

    public GameObject questItem1;
    public GameObject questItem2;
    public GameObject questItem3;


    public GameObject Quest3;

    

    

    public bool isQuest1comp;
    public bool isQuest2comp;
    public bool isQuest3comp;

    

    void Start()
    {

       isQuest1comp = false;
       isQuest2comp = false;
       isQuest3comp = false;

      NPCQuest1.SetActive(true);
      NPCQuest2.SetActive(false);
      NPCQuest3.SetActive(false);


        Quest3.SetActive(false);

        //questItem2.SetActive(false);
        //questItem3.SetActive(false);

    }

    private void Update()
    {
        if (isQuest1comp)
        {            
            NPCQuest1.SetActive(false);
            NPCQuest2.SetActive(true);
            questItem1.SetActive(false);
            questItem2.SetActive(true);
           

        }
        if (isQuest2comp)
        {
            NPCQuest2.SetActive(false);
            NPCQuest3.SetActive(true);            
            questItem2.SetActive(false);
            questItem3.SetActive(true);
            Quest3.SetActive(true);

        }
        if (isQuest3comp)
        {
            questItem3.SetActive(false);
        }

        
    }


    public void quest1Completed()
    {
        isQuest1comp = true;
        
    }

    public void quest2Completed()
    {
        isQuest2comp = true;
    }
    public void quest3Completed()
    {
        isQuest3comp = true;
    }


    
}
