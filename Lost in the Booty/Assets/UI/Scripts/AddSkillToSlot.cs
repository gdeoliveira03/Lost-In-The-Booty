using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddSkillToSlot : MonoBehaviour
{

    public Image original;
    public Sprite NewSprite;
    public Image Skillbackground;
    public TextMeshProUGUI warningtext;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewImage()
    {
        warningtext.gameObject.SetActive(false);
        if(Skillbackground.gameObject.activeSelf == true){
            warningtext.gameObject.SetActive(true);
        }
        else{
            warningtext.gameObject.SetActive(false);
            original.sprite = NewSprite;
            Color currentColor = original.color;
            currentColor.a = 1f;
            original.color = currentColor;
        }
    }

}
