using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class cooler_highlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Text text;
    [SerializeField] private float pressedAnimationSpeed = 0.5f;
    private Color defaultColor;
    void Start()
    {
        defaultColor = text.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red;
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
        yield return new WaitForSeconds(duration);
        text.color = defaultColor;
    }
}
