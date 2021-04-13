using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _moveSpeed = 10;
    float _horizontalInput;
    float _verticalInput;
    Rigidbody2D _myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(_horizontalInput, _verticalInput, 0) * _moveSpeed * Time.deltaTime);
        //Walk();
    }

    private void Walk()
    {
        Vector2 playerVelocity = new Vector2(_horizontalInput, _verticalInput) * _moveSpeed * Time.deltaTime;
        Debug.Log(playerVelocity);
        _myRigidBody.velocity = playerVelocity;
    }
}
