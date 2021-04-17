using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGameObject : MonoBehaviour
{
    Inventory _thisInventory;
    bool _isAttackObject = false;

    private void Start()
    {
        _thisInventory = FindObjectOfType<Inventory>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player" && _isAttackObject == false)
        {
            //Debug.Log("collision");
            bool _pickedUpObject = _thisInventory.AddInventoryItem(this.gameObject.tag);
            if (_pickedUpObject)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
