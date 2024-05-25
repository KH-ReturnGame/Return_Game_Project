using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerStates
{
    //
    IsGround = 0,
    IsAir,
    IsJump,
    IsWall,
    IsDash,
    //
    IsMove,
    IsStun,
    IsAttacked,
    IsAttacking,
}

/// <summary>
/// 플레이어 클래스
/// </summary>
/// <returns></returns>
public class Player : Entity
{
    //플레이어가 가질 수 있는 모든 상태들
    public State[] _states;
    //"현재" 플레이어가 가지고 있는 모든 상태
    public List<State> _currentState;
    
    /// <summary>
    /// Player 클래스의 생성자임, 최대 체력,
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public Player(float hp,GameObject playerPrefab) : base(hp,playerPrefab){}

    public void Awake()
    {
        _states = new State[9];
        _states[(int)PlayerStates.IsGround] = new PlayerOwnedStates.IsGround();
        _states[(int)PlayerStates.IsAir] = new PlayerOwnedStates.IsAir();
        _states[(int)PlayerStates.IsJump] = new PlayerOwnedStates.IsJump();
        _states[(int)PlayerStates.IsWall] = new PlayerOwnedStates.IsWall();
        _states[(int)PlayerStates.IsDash] = new PlayerOwnedStates.IsDash();
        _states[(int)PlayerStates.IsMove] = new PlayerOwnedStates.IsMove();
        _states[(int)PlayerStates.IsStun] = new PlayerOwnedStates.IsStun();
        _states[(int)PlayerStates.IsAttacked] = new PlayerOwnedStates.IsAttacked();
        _states[(int)PlayerStates.IsAttacking] = new PlayerOwnedStates.IsAttacking();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            for (int i = 0; i < _currentState.Count; i++)
            {
                _currentState[i].Execute(this);
            }
        }
    }
    
    public void AddState(State newState)
    {
        _currentState.Add(newState);
        _currentState[_currentState.IndexOf(newState)].Enter(this);
    }
    public void RemoveState(State remState)
    {
        _currentState.Remove(remState);
        _currentState[_currentState.IndexOf(remState)].Exit(this);
    }
}
