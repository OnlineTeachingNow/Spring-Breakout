using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 0.1f;
    Player _player;
    Rigidbody2D _myRigidBody;
    List<Transform> _waypoints;
    bool _hasWaypoints = false;
    int _waypointIndex = 0;
    bool _hasSeenPlayer = false;
    Transform _playerPosition;

    void Start()
    {
       // _player = FindObjectOfType<Player>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (_hasSeenPlayer == false)
        {
            WayPointMovement();
        }
        else
        {
            MoveTowardsPlayer();
        }

        //if no player in sight

        //but if the player is in sight... 
        //pursue player 
        //if player gets out of sight, go to the last place the player was in your sights and recheck to see if the player is in sight again.
    }

    private void WayPointMovement()
    {
        if (_hasWaypoints == true)
        {
            if (Mathf.Abs((this.transform.position - _waypoints[_waypointIndex].transform.position).magnitude) > 0.08)
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, _waypoints[_waypointIndex].transform.position, _moveSpeed);
               // this.transform.LookAt(_waypoints[_waypointIndex].transform.position);
            }
            else
            {
                if (_waypointIndex == _waypoints.Count - 1)
                {
                    _waypointIndex = 0;
                }
                else
                {
                    _waypointIndex++;
                }
            }
        }
    }

    public void HasSeenPlayer(Transform playerPosition)
    {
        _playerPosition = playerPosition;
        _hasSeenPlayer = true;
    }

    private void MoveTowardsPlayer()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, _playerPosition.position, 0.05f);
    }

    public void SetWaypoints(List<Transform> waypoints)
    {
        _waypoints = waypoints;
        _hasWaypoints = true;
        Debug.Log("waypoints have been set");
        Debug.Log("waypoints count: " + _waypoints.Count);
    }    
}