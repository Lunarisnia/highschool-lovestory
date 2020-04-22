using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class image_slideshow : MonoBehaviour
{
    [SerializeField] private float duration = 8f;
    [SerializeField] private float multiplier = 0.25f;
    [SerializeField] private Texture[] images;
    private int selectedImage;
    private RawImage backgroundImage;
    void Start()
    {
        backgroundImage = GetComponent<RawImage>();
        selectedImage = Random.Range(0, images.Length);
        backgroundImage.texture = images[selectedImage];


        StartCoroutine(imageSlider(duration, multiplier));
    }

    IEnumerator imageSlider(float duration, float rawMultiplier)
    {
        float multiplier = rawMultiplier * Time.deltaTime;
        while (true)
        {
            selectedImage++;
            if (selectedImage == images.Length)
            {
                selectedImage = 0;
            }
            yield return new WaitForSeconds(duration);
            for (float i = 1; i >= 0; i -= multiplier)
            {
                yield return 0;
                backgroundImage.color = new Color(1, 1, 1, i);
            }
            backgroundImage.texture = images[selectedImage];
            for (float x = 0; x <= 1; x += multiplier)
            {
                yield return 0;
                backgroundImage.color = new Color(1, 1, 1, x);
            }
        }

    }
}
