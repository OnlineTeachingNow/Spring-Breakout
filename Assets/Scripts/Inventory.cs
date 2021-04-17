using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    InventoryUI _inventoryUI;
    Player _player;
    private List<string> _myInventory = new List<string>();

    private void Start()
    {
        _inventoryUI = FindObjectOfType<InventoryUI>();
        _player = FindObjectOfType<Player>();
    }
    public bool AddInventoryItem(string thisTag)
    {
        bool _pickedUpItem = false;
        if (_myInventory.Count < 2)
        {
            if (!_myInventory.Contains(thisTag))
            {
                _myInventory.Add(thisTag);
                _inventoryUI.AddInventory(thisTag);
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
            Debug.Log(item);
        }
        
        return _pickedUpItem;
    }

    public void DiscardItem(string discardTag)
    {
        if (_myInventory.Count > 0)
        {
            _player.ThrowObject(discardTag);
            _inventoryUI.TakeAwayInventory(discardTag);
            _myInventory.Remove(discardTag);

        }
        else
        {
            Debug.Log("There is no inventory to discard");
        }
    }
}
