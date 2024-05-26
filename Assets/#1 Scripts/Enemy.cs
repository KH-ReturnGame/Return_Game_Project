using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyStates
{
    //
    IsGround = 0,
    IsAir,
    IsJump,
    IsWall,
    //
    IsMove,
    IsStun,
    IsAttacked,
    IsAttacking,
    IsDetect,
    IsDie,
    IsCool,
    // stun은 유니크 몹과 일반 몹을 나눠서 할것
    // 플레이어가 원거리 몹 근처에 얼마나 있었는지를 상태에 구별해서 추가할 것
}

public class Enemy : Entity
{
    //에너미가 가질 수 있는 모든 상태들
    private State[] states;
    //"현재" 에너미가 가지고 있는 모든 상태
    private State[] currentState;

    public override void Setup(float maxHp)
    {
        base.Setup(maxHp);
    }
    public void Awake()
    {
        states = new State[12];
        states[(int)EnemyStates.IsGround] = new EnemyOwnedStates.IsGround();
        states[(int)EnemyStates.IsAir] = new EnemyOwnedStates.IsAir();
        states[(int)EnemyStates.IsJump] = new EnemyOwnedStates.IsJump();
        states[(int)EnemyStates.IsWall] = new EnemyOwnedStates.IsWall();
        states[(int)EnemyStates.IsMove] = new EnemyOwnedStates.IsMove();
        states[(int)EnemyStates.IsStun] = new EnemyOwnedStates.IsStun();
        states[(int)EnemyStates.IsAttacked] = new EnemyOwnedStates.IsAttacked();
        states[(int)EnemyStates.IsAttacking] = new EnemyOwnedStates.IsAttacking();
        states[(int)EnemyStates.IsDetect] = new EnemyOwnedStates.IsDetect();
        states[(int)EnemyStates.IsDie] = new EnemyOwnedStates.IsDie();
        states[(int)EnemyStates.IsCool] = new EnemyOwnedStates.IsCool();
    }
    public override void Updated()
    {
        
    }

}
