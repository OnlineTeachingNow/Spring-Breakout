using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] Enemy[] _enemyArray;
    //List<Transform> _waypoints;

    void Start()
    {
        foreach (Enemy enemy in _enemyArray)
        {
            var _pathWaypoints = enemy.GetEnemyWayPoints();
            EnemyMovement _newEnemy = Instantiate(enemy.GetEnemyPrefab(), _pathWaypoints[0].transform.position, Quaternion.identity);
            _newEnemy.SetWaypoints(_pathWaypoints);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
