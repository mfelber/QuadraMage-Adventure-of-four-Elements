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
    PlayerMovement playerMovement;

    public Dialogue dialogues;
    private Player player;
    PoseidonQuestManager poseidonQuestManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        player = FindObjectOfType<Player>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        poseidonQuestManager = FindObjectOfType<PoseidonQuestManager>();
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

        
        if(player.nearofPoseidonQuest && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            poseidonQuestManager.acceptSaveMarmaid = true;
        }


        if (player.nearofNpcFirstQuest && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            questManager.acceptFirstQuest = true;
        }

        if (player.nearofNpcSecondQuest && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            questManager.acceptSecondQuest = true;

        }

        if (player.nearofNpcThirdQuest && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
            questManager.acceptThirdQuest = true;
        }

        if (WoodBridge.infrontOfBridge && questManager.isQuest3comp == false)
        {
            TriggerDialogue();
        }


        
      
    }


   
    
}