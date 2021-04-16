using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGameObject : MonoBehaviour
{
    Inventory _thisInventory;
    bool _isAttackObject = false;
    private Vector3 _velocity;
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

    public void IsAttackObject(bool isAttackObject)
    {
        _isAttackObject = isAttackObject;
        if (_isAttackObject == true)
        {
            StartCoroutine(Throw());
        }
    }

    private IEnumerator Throw()
    {
        while (Time.deltaTime < 2.0f)
        {
            UpdateVelocity();
            UpdatePosition();
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void UpdateVelocity()
    {
        _velocity += Physics.gravity * Time.deltaTime;
    }

    private void UpdatePosition()
    {
        transform.position += _velocity * Time.deltaTime;
    }
}
