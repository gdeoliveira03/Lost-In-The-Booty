using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scruffy Inventory", menuName = "player/Inventory")]
public class ScruffyInventory : ScriptableObject
{
    public bool Cutlass = true;
    public bool Spear = false;
    public bool Hammer = false;
    public bool Lightning = false;
    public bool Ice = false;
    public bool Fire = false;
    
}
