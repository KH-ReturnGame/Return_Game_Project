using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 생명체의 부모클래스
/// </summary>
/// <returns></returns>
public abstract class Entity : MonoBehaviour
{
    //최대 체력
    public float _maxHp;

    //현재 체력
    private float _currentHp;

    /// <summary>
    /// Entity 클래스 기초 설정을 위한 Setup메소드, 매개변수로 최대체력을 받음
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public virtual void Setup(float maxHp)
    {
        //매개변수로 받은 값들을 지정해주기
        _maxHp = maxHp;
        _currentHp = maxHp;
        //Debug.Log("maxHp : "+_maxHp);
    }

    //hp Get 함수
    public float GetHp()
    {
        return _currentHp;
    }

    //hp  Set 함수
    public void SetHp(float newHp)
    {
        _currentHp = newHp;
    }

    //추상클래스인 updated메소드
    public abstract void Updated();

    /// <summary>
    /// 체력 회복 메서드
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    protected void RecoveryHp(float hp)
    {
        //만약 체력을 회복했을때 최대체력을 넘어간다면 -> 회복 못하게
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

    /// <summary>
    /// 체력 감소 메서드
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public void TakeDamage(float damage)
    {
        //만약 피해를 입었을때 체력이 0이하라면 -> 죽음처리
        if (_currentHp - damage <= 0 && _currentHp != 0)
        {
            Debug.Log(_currentHp+","+damage);
            _currentHp = 0;
        }
        _currentHp -= damage;
    }
}
