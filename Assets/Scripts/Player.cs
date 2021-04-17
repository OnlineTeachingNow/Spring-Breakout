using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2;
    [SerializeField] GameObject[] _objectsToThrow;
    float _horizontalInput;
    float _verticalInput;
    Rigidbody2D _myRigidBody;
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk();
    }

    private void Walk()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        Vector2 _playerVelocity = new Vector2(_horizontalInput, _verticalInput) * _moveSpeed;
        _myRigidBody.velocity = _playerVelocity;
    }

    public void ThrowObject(string gameObject)
    {
        
        Debug.Log("Game objects passed into Player: " + gameObject);
        for (int collectibleIndex = 0; collectibleIndex < _objectsToThrow.Length; collectibleIndex++)
        {
            if (gameObject == _objectsToThrow[collectibleIndex].tag)
            {
                Debug.Log("Game object tag found");
                Instantiate(_objectsToThrow[collectibleIndex], this.transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
