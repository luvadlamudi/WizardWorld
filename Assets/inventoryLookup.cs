using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryLookup : MonoBehaviour
{
    // Start is called before the first frame update
    public int buttonArrayIndex;
    public Inventory AttachedObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDisable()
    {
        AttachedObject.disableParent();
    }
}
