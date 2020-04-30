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
    public GameObject textDialog;
    private bool textOnIteration = false;
    public void startDialogue(Dialogue dialogue)
    {
        textDialog.SetActive(true);
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

        Time.timeScale = 0f;
        player_controller.gameIsPaused = true;
        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if (!textOnIteration)
        {
            StartCoroutine(iterateSentence());
        }
        else
        {
            textOnIteration = !textOnIteration;
        }
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
            if (!textOnIteration)
            {
                textOnIteration = !textOnIteration;
            }

            string sentence = sentences.Dequeue();
            Sprite portrait = portraits.Dequeue();
            foreach (var item in sentence)
            {
                portraitHolder.sprite = portrait;

                if (textOnIteration)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        // TODO : make the dialog skipable when clicking anywhere on the screen
                        displayNextSentence();
                    }
                    textMesh.text = textMesh.text + item;
                }
                else
                {
                    textMesh.text = sentence;
                    yield return null;
                    break;
                }
                yield return null;
            }
            textOnIteration = false;
            yield return null;
            break;
        }
    }

    public void endDialog()
    {
        Time.timeScale = 1f;
        player_controller.gameIsPaused = false;
        textDialog.SetActive(false);
    }
}
