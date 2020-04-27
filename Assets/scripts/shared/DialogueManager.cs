using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences = new Queue<string>();
    private Queue<Sprite> portraits = new Queue<Sprite>();
    public TextMeshProUGUI textMesh;
    public Image portraitHolder;
    public void startDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        portraits.Clear();
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (var portrait in dialogue.portraits)
        {
            portraits.Enqueue(portrait);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        StartCoroutine(iterateSentence());
    }
    public IEnumerator iterateSentence()
    {
        while (true)
        {
            if (sentences.Count == 0)
            {
                endDialog();
                yield return null;
                break;
            }
            textMesh.text = "";

            string sentence = sentences.Dequeue();
            Sprite portrait = portraits.Dequeue();
            foreach (var item in sentence)
            {
                portraitHolder.sprite = portrait;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    textMesh.text = sentence;
                    yield return null;
                    break;
                }
                else
                {
                    textMesh.text = textMesh.text + item;
                }

                yield return null;
            }
            yield return null;
            break;
        }
    }

    public void endDialog()
    {
        // close the dialog bar
        Debug.Log("End dialog");
    }
}
