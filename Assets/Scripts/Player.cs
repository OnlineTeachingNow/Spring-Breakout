using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2;
    [SerializeField] ScriptableAttackObject[] _objectsToThrow;
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

    public void ThrowObject(string gameObjectTag)
    {
        
        for (int collectibleIndex = 0; collectibleIndex < _objectsToThrow.Length; collectibleIndex++)
        {
            if (gameObjectTag == _objectsToThrow[collectibleIndex].tagOfObject)
            {
                var _newObject = Instantiate(_objectsToThrow[collectibleIndex]._sprite, this.transform.position, Quaternion.identity);
                _newObject.SetDistractionTime(_objectsToThrow[collectibleIndex].ReturnDistractionTime()); //passes in the distraction time from scriptable object
                break;
            }
            else
            {
                Debug.Log("object tag: " + _objectsToThrow[collectibleIndex].tagOfObject);
                Debug.Log("no game object matches.");
            }
        }
    }
}
