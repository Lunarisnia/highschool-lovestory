using UnityEngine;
using UnityEngine.UI;

public class random_images : MonoBehaviour
{
    [SerializeField] private RawImage loadingBackground;
    [SerializeField] private Texture[] images;
    void Start()
    {
        loadingBackground.texture = images[Random.Range(0, images.Length)];
    }
}
