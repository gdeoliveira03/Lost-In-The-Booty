using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StatsPageUI : MonoBehaviour
{
    [SerializeField]
    private Toggle Cutlass;

    [SerializeField]
    private Toggle Spear;

    [SerializeField]
    private Toggle Hammer;

    [SerializeField]
    private Toggle Fire;

    [SerializeField]
    private Toggle Ice;

    [SerializeField]
    private Toggle Lightning;

    // Start is called before the first frame update
    void Start()
    {
        Cutlass.isOn = GameManager.Instance.scruffyInventory.Cutlass;
        Spear.isOn = GameManager.Instance.scruffyInventory.Spear;
        Hammer.isOn = GameManager.Instance.scruffyInventory.Hammer;
        Fire.isOn = GameManager.Instance.scruffyInventory.Fire;
        Ice.isOn = GameManager.Instance.scruffyInventory.Ice;
        Lightning.isOn = GameManager.Instance.scruffyInventory.Lightning;
    }
}
