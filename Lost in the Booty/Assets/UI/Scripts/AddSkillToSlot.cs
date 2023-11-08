using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSkillToSlot : MonoBehaviour
{

    public Image original;
    public Sprite NewSprite;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewImage()
    {
        original.sprite = NewSprite;
        Color currentColor = original.color;
        currentColor.a = 1f;
        original.color = currentColor;

    }

}
