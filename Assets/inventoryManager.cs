using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{

    public Inventory[] inventory;

    void Start()
    {
        checkAllItems();
    }

    bool checkIfItemIsEqipped(Inventory inventory)
    {
        return inventory.equipped; 
    }
    

    void checkAllItems()
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            inventory[i].gameObject.SetActive(checkIfItemIsEqipped(inventory[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
