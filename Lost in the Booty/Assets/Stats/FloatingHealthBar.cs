using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField, HideInInspector] private Camera camera;
    [SerializeField] private Transform target;

    private void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    public void UpdateHealthBar(float CurrentValue, float MaxValue){
        slider.value = CurrentValue / MaxValue;
    }

    void Update(){
         transform.rotation = camera.transform.rotation;
    }

}
