using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class tooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltip;
    string desc;
    GameObject tooltipActive;
    // Start is called before the first frame update
    void Start()
    {
        desc = GetComponent<inventoryLookup>().AttachedObject.desc;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addTooltip()
    {
        tooltipActive = GameObject.Instantiate(tooltip, gameObject.transform.position + new Vector3(-50, 10, 0), gameObject.transform.rotation);

        tooltipActive.transform.SetParent(transform);

        Text temp = tooltipActive.GetComponent<Text>();

        if ( temp )
        {
            temp.text = desc;
        }
    }

    void removeTooltip()
    {
        GameObject.Destroy(tooltipActive);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        addTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        removeTooltip();
    }
}
