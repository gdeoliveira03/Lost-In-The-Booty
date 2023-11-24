using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSlideshow : MonoBehaviour
{
    public Texture[] panelImages; // Set panel images in the Inspector
    public float slideDuration = 5f; // Time each image is displayed

    private RawImage rawImageComponent;
    private int currentIndex = 0;

    void Start()
    {
        rawImageComponent = GetComponent<RawImage>();
        StartCoroutine(ChangeSlide());
    }

    IEnumerator ChangeSlide()
    {
        while (true)
        {
            yield return new WaitForSeconds(slideDuration);
            currentIndex = (currentIndex + 1) % panelImages.Length;
            rawImageComponent.texture = panelImages[currentIndex];
        }
    }
}