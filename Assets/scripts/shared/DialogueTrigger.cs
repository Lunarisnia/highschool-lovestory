using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    private void Awake()
    {
        enqueueDialog();
    }

    public void triggerDialog()
    {
        if (dialogueQueue.Count <= 0)
        {
            enqueueDialog();
        }
        Dialogue dialogue = dialogueQueue.Dequeue();
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

    private void enqueueDialog()
    {
        foreach (var dialogue in dialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }
    }
}
