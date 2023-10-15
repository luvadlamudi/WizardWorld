using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int index;

    public bool equipped;

    public string desc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableParent()
    {
        gameObject.transform.parent.gameObject.SetActive(!gameObject.transform.parent.gameObject.activeInHierarchy);
    }
}
