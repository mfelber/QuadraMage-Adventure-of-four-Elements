using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
     public string line;
}



[System.Serializable]
public class Dialogue
{
    [SerializeField] public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
public class DialogTrigger : MonoBehaviour
{
    QuestManager questManager;

    public Dialogue dialogues;


    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }
    private void TriggerDialogue()
    {
        DialogManager.instance.StartDialogue(dialogues);
       
    }

    private void Update()
    {
        if (Player.inRangeOfNPC && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            
           
           
        }

        if (WoodBridge.infrontOfBridge && questManager.isQuest3comp == false)
        {
            TriggerDialogue();
        }
        
    }


    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
                TriggerDialogue();
            
        }
    }
    
   */
    
}