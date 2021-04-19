using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    InventoryUI _inventoryUI;
    ErrorMessagesScript _errorMessages;
    MenuManager _menuManager;
    int _points;
    Player _player;
    int _itemValue;
    private List<string> _myInventory = new List<string>();

    private void Start()
    {
        _errorMessages = FindObjectOfType<ErrorMessagesScript>();
        _menuManager = FindObjectOfType<MenuManager>();
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
                _errorMessages.DisplayErrorMessage("You already have this item.", false);
                _pickedUpItem = false;
            }
        }
        else
        {
            _errorMessages.DisplayErrorMessage("Inventory Full. Please discard an item.", false);
            _pickedUpItem = false;
        }
        /*
        foreach (var item in _myInventory)
        {
            Debug.Log(item);
        }
        */
        
        return _pickedUpItem;
    }

    public void SetItemValue(int itemValue)
    {
        _itemValue = itemValue;
    }

    public void DiscardItem(string discardTag)
    {
        int _points = _menuManager.GetPoints();
        if (_myInventory.Count > 0)
        {
            if (_points >= _itemValue)
            {
                _player.ThrowObject(discardTag);
                _inventoryUI.TakeAwayInventory(discardTag);
                _myInventory.Remove(discardTag);
            }
            else
            {
                _errorMessages.DisplayErrorMessage("Not enough points.", false);
            }
        }
        else
        {
            _errorMessages.DisplayErrorMessage("There are no items to discard", false);
        }
    }
}
