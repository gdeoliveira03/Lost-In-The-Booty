using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField, HideInInspector] private Camera camera;
    [SerializeField] private Transform target;

    public void UpdateHealthBar(float CurrentValue, float MaxValue){
        slider.value = CurrentValue / MaxValue;
    }
}
