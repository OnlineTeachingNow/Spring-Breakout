using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Button[] _childrenColors;

    // Start is called before the first frame update
    void Start()
    {
        _childrenColors = gameObject.GetComponentsInChildren<Button>();
        foreach (var child in _childrenColors)
        {
            child.enabled = false;
            child.GetComponent<Image>().color = new Color32(85, 76, 76, 255);
        }
    }

    public void AddInventory(string objectTag)
    {
        foreach (var child in _childrenColors)
        {
            if (child.tag == objectTag)
            {
                child.enabled = true;
                child.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    public void TakeAwayInventory(string objectTag)
    {
        foreach (var child in _childrenColors)
        {
            if (child.tag == objectTag)
            {
                child.GetComponent<Image>().color = new Color32(85, 76, 76, 255);
                child.enabled = false;
            }
        }
    }

}
