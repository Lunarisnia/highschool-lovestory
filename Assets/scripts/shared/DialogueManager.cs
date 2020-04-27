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
                //TODO : MAKE IT SKIP TO ALL MESSAGE BUT NOT TO THE NEXT WHEN A BUTTON IS PRESSED WHILE THIS RUN
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
        Time.timeScale = 1f;
        player_controller.gameIsPaused = false;
        textDialog.SetActive(false);
    }
}
