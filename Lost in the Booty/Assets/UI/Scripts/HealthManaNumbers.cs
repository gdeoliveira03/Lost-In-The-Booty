using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManaNumbers : MonoBehaviour
{
    public TextMeshProUGUI percentageTextHealth;
    public TextMeshProUGUI percentageTextMana;
    public Slider HPBar;
    public Slider ManaBar;

    // Update is called once per frame
    void Update()
    {
        float maxHPValue = HPBar.maxValue;
        float currentHPValue = HPBar.value;

        float maxManaValue = ManaBar.maxValue;
        float currentManaValue = ManaBar.value;

        percentageTextHealth.text = currentHPValue + " / " + maxHPValue;
        percentageTextMana.text = currentManaValue + " / " + maxManaValue;
    }
}
