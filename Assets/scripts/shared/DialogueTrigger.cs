using UnityEngine;
using System.Collections.Generic;

public class DialogueTrigger : MonoBehaviour
{
    // TODO : Maybe fix this a little bit for this goes random
    // TODO : Make it close when dialogue is over
    // TODO : Make it trigger when you click an npc
    public Dialogue[] dialogues;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    private void Awake() {
        foreach (var dialogue in dialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }
    }

    public void triggerDialog()
    {
        Dialogue dialogue = dialogueQueue.Dequeue();
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }
}
