using System.Collections.Generic;
using UnityEngine;


/*
[System.Serializable]
public class Quest
{
    public int id;
    public string name;
    public Dialogue associatedDialogue;
    public bool completed;
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();

}
*/
public class QuestManager : MonoBehaviour
{
    //public List<Quest> quests = new List<Quest>();

    public GameObject StrangerQuest1;
    public GameObject StrangerQuest2;
    public GameObject StrangerQuest3;

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
        StrangerQuest2.SetActive(false);




    }

    private void Update()
    {
        if (isQuest1comp)
        {
            
            StrangerQuest1.SetActive(false);
            StrangerQuest2.SetActive(true);

            //StrangerQuest2.transform.position = new Vector2(36.36f, 0.26f);
        }
        if (isQuest2comp)
        {
            StrangerQuest2.SetActive(false);
            StrangerQuest3.transform.position = new Vector2(36.36f, 0.26f);
        }

        //Debug.LogError(isQuest1comp);
    }


    public void quest1Completed()
    {
        isQuest1comp = true;
        Debug.LogError(isQuest1comp);
    }

    public void quest2Completed()
    {
        isQuest2comp = true;
    }
    public void quest3Completed()
    {
        isQuest3comp = true;
    }


    /*
    public void CompleteQuest(Quest quest)
    {
        quest.completed = true;
    }
    */
}
