using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    QuestManager questManager;

    public Image characterIcon;
    public TextMeshProUGUI charactername;
    public TextMeshProUGUI dialogArea;

    private Queue<DialogueLine> lines;

    public static bool isDialgueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        lines = new Queue<DialogueLine>();
        questManager = FindObjectOfType<QuestManager>();
    }

   


    public void StartDialogue(Dialogue dialogue)
    {
        isDialgueActive = true;

        animator.Play("show");
        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentiLine = lines.Dequeue();
        characterIcon.sprite = currentiLine.character.icon;
        charactername.text = currentiLine.character.name;

        StopAllCoroutines();
        //StopCoroutine(TypeSentence(currentiLine));
        StartCoroutine(TypeSentence(currentiLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogArea.text = "";
        foreach (char character in dialogueLine.line.ToCharArray())
        {
            dialogArea.text += character;
            yield return new WaitForSeconds(typingSpeed);
        }

    }



    public void EndDialogue()
    {
        
        isDialgueActive = false;
        animator.Play("hide");

        
            
        
    }
}