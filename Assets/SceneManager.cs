using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    GameObject inventoryUI;

    public GameObject[] buttonPrefabs;

    public Button[] buttons;

    inventoryManager inventoryManager;

    void Start()
    {
        inventoryUI = GameObject.Find("InventoryUI");
        inventoryManager = GameObject.Find("Inventory").GetComponent<inventoryManager>();

        checkAllInventory();
    }

    void checkAllInventory()
    {
        for(int i = 0; i< inventoryManager.inventory.Length; i++)
        {
            for(int j = 0; j < buttonPrefabs.Length; j++)
            {

                if ( inventoryManager.inventory[i].equipped && buttonPrefabs[j].name.Contains(inventoryManager.inventory[i].name)) {

                    int indexForButtonsArray = getFirstAvailableIndexInButtonArray();

                    GameObject invenTemp = GameObject.Instantiate(buttonPrefabs[j], buttons[indexForButtonsArray].transform.position, buttons[indexForButtonsArray].transform.rotation);

                    inventoryLookup tempLookUp = invenTemp.GetComponent<inventoryLookup>();

                    if ( tempLookUp == null )
                    {
                        invenTemp.AddComponent<inventoryLookup>();
                    }

                    tempLookUp.buttonArrayIndex = indexForButtonsArray;
                    tempLookUp.AttachedObject = inventoryManager.inventory[i];

                    invenTemp.transform.SetParent(inventoryUI.transform);
                }
            }
        }
    }

    int getFirstAvailableIndexInButtonArray()
    {
        for(int i = 0; i< buttons.Length; i++)
        {
            Text temp = buttons[i].transform.GetChild(0).gameObject.GetComponent<Text>();
            if (temp.text == "")
            {
                return i;
            } 
        }

        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        }
    }
}
