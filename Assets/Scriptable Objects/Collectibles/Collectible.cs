using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible.asset", menuName = "Collectible")]
public class Collectible : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _healthValue;
    [SerializeField] private int _socialValue;

    public string ReturnName()
    {
        return _name;
    }

    public string ReturnDescription()
    {
        return _description;
    }

    public int ReturnHealth()
    {
        return _healthValue;
    }

    public int ReturnSocial()
    {
        return _socialValue;
    }
}
