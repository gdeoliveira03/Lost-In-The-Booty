using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScruffyInventory scruffyInventory;

    public static GameManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //scruffyInventory = ScriptableObject.CreateInstance<ScruffyInventory>();

            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            throw new Exception();
        }
    }
   
}
