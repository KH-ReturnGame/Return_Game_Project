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
    private State[] states;
    //"현재" 플레이어가 가지고 있는 모든 상태
    private State[] currentState;
    
    
    
    /// <summary>
    /// Player 클래스의 생성자임, 최대 체력,
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public Player(float hp,GameObject playerPrefab) : base(hp,playerPrefab){}
}
