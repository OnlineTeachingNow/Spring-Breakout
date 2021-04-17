using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackObject.asset", menuName = "AttackObject")]
public class ScriptableAttackObject : ScriptableObject
{
    [SerializeField] private int _distractionTime;
    [SerializeField] private int _costToUse;
    [SerializeField] private AttackObject _sprite;

    public int ReturnDistractionTime()
    {
        return _distractionTime;
    }

    public int ReturnCostToUse()
    {
        return _costToUse;
    }
}
