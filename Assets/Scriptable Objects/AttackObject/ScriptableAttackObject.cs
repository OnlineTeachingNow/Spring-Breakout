using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackObject.asset", menuName = "AttackObject")]
public class ScriptableAttackObject : ScriptableObject
{
    [SerializeField] private float _distractionTime;
    [SerializeField] private float _costToUse;
    public AttackObject _sprite;
    public string tagOfObject;

    public float ReturnDistractionTime()
    {
        return _distractionTime;
    }

    public float ReturnCostToUse()
    {
        return _costToUse;
    }
}
