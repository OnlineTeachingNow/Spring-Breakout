using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2;
    float _horizontalInput;
    float _verticalInput;
    Rigidbody2D _myRigidBody;
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Walk();
        WalkAgain();
    }

    private void WalkAgain()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        Vector2 _playerVelocity = new Vector2(_horizontalInput, _verticalInput) * _moveSpeed;
        _myRigidBody.velocity = _playerVelocity;
    }
    private void Walk()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        this.transform.Translate(new Vector3(_horizontalInput, _verticalInput, 0) * _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("In collision");
    }
}
