using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity: MonoBehaviour
{
    private float _maxHp;
    private float _currentHp;

    void RecoveryHp(float hp)
    {
        if (_currentHp + hp > _maxHp)
        {
            Debug.Log("cant recovery");
            _currentHp = _maxHp;
        }
        else
        {
            _currentHp += hp;
        }
    }

    void TakeDamage(float hp)
    {
        if (_currentHp - hp <= 0)
        {
            Debug.Log("gg");
            _currentHp = 0;
        }
        _currentHp -= hp;
    }
}
