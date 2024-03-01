using System.Collections.Generic;
using UnityEngine;



public class QuestManager : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();


    public GameObject StrangerQuest1;
    public GameObject StrangerQuest2;
    public GameObject StrangerQuest3;

    public GameObject questItem1;
    public GameObject questItem2;
    public GameObject questItem3;

    

    public bool isQuest1comp;
    public bool isQuest2comp;
    public bool isQuest3comp;

    

    void Start()
    {

       isQuest1comp = false;
       isQuest2comp = false;
       isQuest3comp = false;

      StrangerQuest1.SetActive(true);
      StrangerQuest2.SetActive(false);
      StrangerQuest3.SetActive(false);


        //questItem2.SetActive(false);
        //questItem3.SetActive(false);

    }

    private void Update()
    {
        if (isQuest1comp)
        {            
            StrangerQuest1.SetActive(false);
            StrangerQuest2.SetActive(true);
            questItem1.SetActive(false);
            questItem2.SetActive(true);
           

        }
        if (isQuest2comp)
        {
            StrangerQuest2.SetActive(false);
            StrangerQuest3.SetActive(true);            
            questItem2.SetActive(false);
            questItem3.SetActive(true);

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
