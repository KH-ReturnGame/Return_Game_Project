using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 생명체의 부모클래스
/// </summary>
/// <returns></returns>
public class Entity : MonoBehaviour
{
    //최대 체력
    private float _maxHp;
    
    //현재 체력
    private float _currentHp;

    /// <summary>
    /// Entity 클래스의 생성자임, 매개변수로 최대체력과 생성할 생명체의 Prefab를 받음
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public Entity(float maxHp,GameObject createObj)
    {
        //매개변수로 받은 값들을 지정해주기
        _maxHp = maxHp;
        _currentHp = maxHp;
        
        //생명체를 생성
        Instantiate(createObj);
        
        Debug.Log("maxHp : "+_maxHp);
    }

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
    protected void TakeDamage(float hp)
    {
        //만약 피해를 입었을때 체력이 0이하라면 -> 죽음처리
        if (_currentHp - hp <= 0)
        {
            Debug.Log("gg");
            _currentHp = 0;
        }
        _currentHp -= hp;
    }
    
    public void AddState(State newState, ref List<State> currentState, Player player)
    {
        currentState.Add(newState);
        currentState[currentState.IndexOf(newState)].Enter(player);
    }
    public void RemoveState(State remState, ref List<State> currentState, Player player)
    {
        currentState.Remove(remState);
        currentState[currentState.IndexOf(remState)].Exit(player);
    }
}
