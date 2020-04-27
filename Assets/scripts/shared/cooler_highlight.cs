using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class cooler_highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private float pressedAnimationSpeed = 0.5f;
    [SerializeField] private AudioSet audioSetting;
    private AudioSource aud;
    private Color defaultColor;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        defaultColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red;
        setAndPlayAudio(audioSetting.highlightSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = defaultColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(pressedCoroutine(pressedAnimationSpeed));
    }
    IEnumerator pressedCoroutine(float duration)
    {
        text.color = Color.cyan;
        setAndPlayAudio(audioSetting.confirmSound);
        yield return new WaitForSeconds(duration);
        text.color = defaultColor;
    }

    public void setAndPlayAudio(AudioClip audio)
    {
        aud.clip = audio;
        aud.Play();
    }
}
