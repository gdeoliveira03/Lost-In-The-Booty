using UnityEngine;


[System.Serializable]
public class Stat 
{

    [SerializeField]
    private int baseValue;

    public int getValue ()
    {
        return baseValue;
    }

}
