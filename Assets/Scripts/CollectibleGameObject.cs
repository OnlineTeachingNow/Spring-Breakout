using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGameObject : MonoBehaviour
{
    Inventory _thisInventory;
    AudioSource _thisAudio;
    Transform _mainCameraPosition;

    private void Start()
    {
        _thisInventory = FindObjectOfType<Inventory>();
        _thisAudio = GetComponent<AudioSource>();
        _mainCameraPosition = FindObjectOfType<Camera>().transform;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            bool _pickedUpObject = _thisInventory.AddInventoryItem(this.gameObject.tag);
            if (_pickedUpObject)
            {
                AudioSource.PlayClipAtPoint(_thisAudio.clip, _mainCameraPosition.position, 1.0f);
                Destroy(this.gameObject);
            }
        }
    }
}
