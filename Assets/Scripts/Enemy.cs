using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.1f;
    Player _player;
    Rigidbody2D _myRigidBody;
   
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _moveSpeed);
    }
}
