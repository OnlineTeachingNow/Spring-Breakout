using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Button[] childrenColors = gameObject.GetComponentsInChildren<Button>();
        foreach (var child in childrenColors)
        {
            child.GetComponent<Image>().color = new Color(85, 76, 76);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
