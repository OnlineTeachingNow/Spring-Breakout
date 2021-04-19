using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5f;
    Player _player;
    Rigidbody2D _myRigidBody;
    List<Transform> _waypoints;
    bool _hasWaypoints = false;
    int _waypointIndex = 0;
    bool _hasSeenObject = false;
    string _objectTag; 
    Transform _positionOfObjectToPursue;
    List<Transform> _objectsToPursue = new List<Transform>();
    Vector2 _enemyDirection;

    void Start()
    {
       // _player = FindObjectOfType<Player>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void SetMoveSpeed(float movespeed)
    {
        _moveSpeed = movespeed;
    }

    void Update()
    {
        if (_hasSeenObject == false)
        {
            WayPointMovement();
        }
        else
        {
            PursueObject();
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
                Vector3 _firstLocation = this.transform.position; 
                this.transform.position = Vector2.MoveTowards(this.transform.position, _waypoints[_waypointIndex].transform.position, _moveSpeed * Time.deltaTime);
                _enemyDirection = (this.transform.position - _firstLocation).normalized;
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

    public void HasSeenObjectToPursue(Transform objectPosition)
    {
        _positionOfObjectToPursue = objectPosition;
        _hasSeenObject = true;
        Debug.Log("has seen object to pursue");
    }

    
    public Vector2 GetEnemyVelocity()
    {
        return _enemyDirection;
    }
    

    private void PursueObject()
    {
        if (_positionOfObjectToPursue != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _positionOfObjectToPursue.position, _moveSpeed * Time.deltaTime);
        }
        else
        {
            _hasSeenObject = false;
        }
        /*
        Debug.Log("Number of objects to pursue" + _objectsToPursue.Count);
        if (_objectsToPursue.Count == 1)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _objectsToPursue[0].position, _moveSpeed * Time.deltaTime);
        }
        else if (_objectsToPursue.Count > 1)
        {
            for (int pursueObjectIndex = 0; pursueObjectIndex < _objectsToPursue.Count; pursueObjectIndex++)
            {
                if (_objectsToPursue[pursueObjectIndex].tag == "player")
                {
                    _objectsToPursue.RemoveAt(pursueObjectIndex);
                    _objectsToPursue.Add(_objectsToPursue[pursueObjectIndex]);
                }
                this.transform.position = Vector2.MoveTowards(this.transform.position, _objectsToPursue[pursueObjectIndex].position, _moveSpeed * Time.deltaTime);
            }
        }   
        */
    }

    public void SetWaypoints(List<Transform> waypoints)
    {
        _waypoints = waypoints;
        _hasWaypoints = true;
    }    
}
