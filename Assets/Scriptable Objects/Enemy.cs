using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy.asset", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [SerializeField] private EnemyMovement _enemy;
    [SerializeField] private GameObject _enemyPath;
    [SerializeField] private bool _isLooping;

    public List<Transform> GetEnemyWayPoints()
    {
        List<Transform> _pathWayPoints = new List<Transform>();
        foreach (Transform child in _enemyPath.transform)
        {
            _pathWayPoints.Add(child);
        }
        return _pathWayPoints;
    }

    public EnemyMovement GetEnemyPrefab()
    {
        return _enemy;
    }

    public bool IsEnemyLooping()
    {
        return _isLooping;
    }
}
