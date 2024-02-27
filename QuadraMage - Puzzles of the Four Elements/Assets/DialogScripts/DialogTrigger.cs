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
    public string questName;
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
public class DialogTrigger : MonoBehaviour
{

    public Dialogue questDialogue;

    public void TriggerDialogue()
    {
        DialogManager.instance.StartDialogue(questDialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("kolizia hraca s strangerom");
        if (collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }
}