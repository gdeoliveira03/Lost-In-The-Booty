using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryUI;

    // Start is called before the first frame update
    public void openInventory(){
        Time.timeScale = 0f;
        InventoryUI.SetActive(true);
    }

    public void closeInventory(){
        Time.timeScale = 1f;
        InventoryUI.SetActive(false);
    }

    void Update () {
    }
}
