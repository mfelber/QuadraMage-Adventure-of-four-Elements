using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public int id;
    public string name;
    
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();

}

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
   

    void Start()
    {

        /*
        Quest quest1 = new Quest(1, "First Quest");
        quest1.dialogs.Add("Dialog 1 for Quest 1");
        quest1.dialogs.Add("Dialog 2 for Quest 1");
        quests.Add(quest1);

        Quest quest2 = new Quest(2, "Second Quest");
        quest2.dialogs.Add("Dialog 1 for Quest 2");
        quest2.dialogs.Add("Dialog 2 for Quest 2");
        quests.Add(quest2);
        */
        
        
    }

    
}
