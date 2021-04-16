using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<string> _myInventory = new List<string>();
    public bool AddInventoryItem(string thisTag)
    {
        bool _pickedUpItem = false;
        if (_myInventory.Count < 2)
        {
            if (!_myInventory.Contains(thisTag))
            {
                _myInventory.Add(thisTag);
                _pickedUpItem = true;
            }
            else
            {
                Debug.Log("Already have this item.");
                _pickedUpItem = false;
            }
        }
        else
        {
            Debug.Log("Inventory Full. Please discard an item before picking another up");
            _pickedUpItem = false;
        }
        foreach (var item in _myInventory)
        {
           // Debug.Log(item);
        }
        return _pickedUpItem;




        /*
        bool _pickedUpObject = false;
        if (_myInventory.Count < 2)
        {
            for (int _availableInventoryIndex = 0; _availableInventoryIndex < _availableInventoryItems.Length; _availableInventoryIndex++)
            {
                if (itemName == _availableInventoryItems[_availableInventoryIndex].name)
                {
                    if (_myInventory.Count > 0)
                    {
                        foreach (var item in _myInventory)
                        {
                            Debug.Log("Item name: " + item.name);
                            if (itemName == item.name)
                            {
                                _pickedUpObject = false;
                                Debug.Log("Already have item in inventory");
                            }
                            else
                            {
                                _myInventory.Add(_availableInventoryItems[_availableInventoryIndex]);
                                Debug.Log("Picked up item. Number of Items in Inventory now: " + _myInventory.Count);
                                _pickedUpObject = true;
                            }
                        }
                    }
                    else
                    {
                        _myInventory.Add(_availableInventoryItems[_availableInventoryIndex]);
                        Debug.Log("Picked up item. Number of Items in Inventory now: " + _myInventory.Count);
                        _pickedUpObject = true;
                    }
                }
            }
            return _pickedUpObject;
        }
        else
        {
            Debug.Log("Inventory full. Please discard an item.");
            return _pickedUpObject;
        }
        */
    }
}
