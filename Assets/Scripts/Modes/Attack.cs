using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    private float _damage;
    public float Damage
    {
        get
        {
            return _damage;
        }
    }

    public Attack(float damage)
    {
        _damage = damage;
    }
}