using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float _viewRadius;
    [Range(0,180)]
    public float _viewAngle;

    public LayerMask _layerMask; 
    public LayerMask _obstacleMask;

    public List<Transform> _visibleTargets = new List<Transform>();

    Vector2 _enemyVelocity;

    private void Start()
    {
        StartCoroutine(FindTargetsWithDelay(0.2f));
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            _enemyVelocity = GetComponent<EnemyMovement>().GetEnemyVelocity();
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        _visibleTargets.Clear();
        Collider2D[] _targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _layerMask); //Checks only for objects in the layers
        for (int i = 0; i < _targetsInViewRadius.Length; i++)
        {
            Transform _target = _targetsInViewRadius[i].transform;
            Vector3 _dirToTarget = (_target.position - transform.position).normalized;
            if (Vector3.Angle(_enemyVelocity, _dirToTarget) < _viewAngle/2)
            {
                float _dstToTarget = Vector3.Distance(transform.position, _target.position);

                if (!Physics2D.Raycast(transform.position, _dirToTarget, _dstToTarget, _obstacleMask))
                {
                    _visibleTargets.Add(_target);
                    if (_target.tag != "player")
                    {
                        GetComponent<EnemyMovement>().HasSeenObjectToPursue(_target);
                    }
                    else
                    {
                        GetComponent<EnemyMovement>().HasSeenObjectToPursue(_target);
                    }
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += -transform.eulerAngles.z;
        }
        
        if (_enemyVelocity == new Vector2(0, 1))
        {
            return new Vector2(Mathf.Sin((angleInDegrees) * Mathf.Deg2Rad), Mathf.Cos((angleInDegrees) * Mathf.Deg2Rad));
        }
        else if (_enemyVelocity == new Vector2(1, 0))
        {
            return new Vector2(Mathf.Sin((angleInDegrees + 90) * Mathf.Deg2Rad), Mathf.Cos((angleInDegrees + 90) * Mathf.Deg2Rad));
        }
        else if (_enemyVelocity == new Vector2(0, -1))
        {
            return new Vector2(Mathf.Sin((angleInDegrees + 180) * Mathf.Deg2Rad), Mathf.Cos((angleInDegrees + 180) * Mathf.Deg2Rad));
        }
        else if (_enemyVelocity == new Vector2(-1, 0))
        {
            return new Vector2(Mathf.Sin((angleInDegrees + 270) * Mathf.Deg2Rad), Mathf.Cos((angleInDegrees + 270) * Mathf.Deg2Rad));
        }
        else
        {
            return new Vector2(Mathf.Sin((angleInDegrees) * Mathf.Deg2Rad), Mathf.Cos((angleInDegrees) * Mathf.Deg2Rad)); //if nothing else returns, I still get a field of view.
        }
    }
}
