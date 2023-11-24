using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageSlideshow : MonoBehaviour
{
    public Sprite[] images; // Drag and drop your images into this array in the Inspector
    public float slideDuration = 5f; // Time each image is displayed

    private Image imageComponent;
    private int currentIndex = 0;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        StartCoroutine(ChangeSlide());
    }

    IEnumerator ChangeSlide()
    {
        while (true)
        {
            yield return new WaitForSeconds(slideDuration);
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = images[currentIndex];
        }
    }
}
