using System.Collections.Generic;
using UnityEngine;



public class QuestManager : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();


   public GameObject NPCQuest1;
    public GameObject NPCQuest2;
    public GameObject NPCQuest3;

    [SerializeField] private GameObject questItem1;
    [SerializeField] private GameObject questItem2;
    [SerializeField] private GameObject questItem3;


    [SerializeField] private GameObject Quest3;





     public bool isQuest1comp;
     public bool isQuest2comp;
     public bool isQuest3comp;

    [SerializeField] private bool npc1Vis;
    [SerializeField] private bool npc2Vis;
    [SerializeField] private bool npc3Vis;

    public int questNumber;
    public bool acceptFirstQuest;
    

    void Start()
    {

        questNumber = 1;
        acceptFirstQuest = false;
       isQuest1comp = false;
       isQuest2comp = false;
       isQuest3comp = false;

        NPCQuest1.SetActive(false);
        NPCQuest2.SetActive(false);
        NPCQuest3.SetActive(false);

      //NPCQuest2.SetActive(false);
     //NPCQuest3.SetActive(false);

        npc1Vis = true;
        npc2Vis = false;
        npc3Vis = false;


        Quest3.SetActive(false);

        //questItem2.SetActive(false);
        //questItem3.SetActive(false);

    }

    private void Update()
    {
        if (isQuest1comp && NPCQuest1.activeSelf)
        {
            
                npc2Vis = true;
            //Destroy(NPCQuest1);
            
            NPCQuest1.SetActive(false);
            
            NPCQuest2.SetActive(true);
            npc1Vis = false;        
            questItem1.SetActive(false);
            questItem2.SetActive(true);
           
           

        }
        if (isQuest2comp && NPCQuest2.activeSelf)
        {
            npc2Vis = false;
            npc3Vis = true;
            //Destroy(NPCQuest2);

           
                NPCQuest2.SetActive(false);
            

            
            
            NPCQuest3.SetActive(true);
            setInVisibleNPC2();
            setVisibleNPC3();
            //NPCQuest2.SetActive(false);
           
            //NPCQuest3.SetActive(true);            
            questItem2.SetActive(false);
            //questItem3.SetActive(true);
            //Quest3.SetActive(true);

        }
        if (isQuest3comp && questNumber == 3)
        {
            questItem3.SetActive(false);
        }

        //Debug.Log("npc 1 visible"+ npc1Vis);
        //Debug.Log("npc 2 visible"+ npc2Vis);
        
    }

    public bool isNpc1Vis
    {
        get { return npc1Vis; }
    }

    public bool isNpc2Vis
    {
        get { return npc2Vis; }
    }

    public bool isNpc3Vis
    {
        get { return npc3Vis; }
    }

    public int getQuestNumber
    {
        get { return questNumber; }
    }

    public void setInVisibleNPC1 ()
    {
        NPCQuest1.SetActive(false);
        
    }

    public void setVisibleNPC1()
    {
        
        NPCQuest1.SetActive(true);
    }

    public void setInVisibleNPC2()
    {
        Debug.Log("metoda sa vykonala");
        NPCQuest2.SetActive(false);
       
    }

    public void setVisibleNPC2()
    {
        NPCQuest2.SetActive(true);
        
        
    }

    public void setVisibleNPC3()
    {
        NPCQuest3.SetActive(true);
        
    }

    public void setInVisibleNPC3()
    {
        NPCQuest3.SetActive(false);
        
    }


    public void quest1Completed()
    {
        
        isQuest1comp = true;
        questNumber++;
        
    }

    public void quest2Completed()
    {
        isQuest2comp = true;
        questNumber++;
    }
    public void quest3Completed()
    {
        isQuest3comp = true;
    }



   

}
