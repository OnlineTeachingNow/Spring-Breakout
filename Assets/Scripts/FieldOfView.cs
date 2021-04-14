using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float _viewRadius;
    [Range(0,360)]
    public float _viewAngle;

    public LayerMask _layerMask; 
    public LayerMask _obstacleMask;

    private void Start()
    {
        StartCoroutine(FindTargetsWithDelay(0.5f));
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    void FindVisibleTargets()
    {
        Collider2D[] _targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _layerMask); //Checks only for objects in the layers
        for (int i = 0; i < _targetsInViewRadius.Length; i++)
        {
            Transform _target = _targetsInViewRadius[i].transform;
            Vector3 _dirToTarget = (_target.position - transform.position).normalized;
            if (Vector3.Angle(transform.up, _dirToTarget) < _viewAngle/2)
            {
                float _dstToTarget = Vector3.Distance(transform.position, _target.position);

                if (!Physics2D.Raycast(transform.position, _dirToTarget, _dstToTarget, _obstacleMask))
                {
                    GetComponent<EnemyMovement>().HasSeenPlayer(_target);
                }
            }
        }
    }

    public Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
