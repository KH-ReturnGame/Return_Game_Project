using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//플레이어가 가질 수 있는 모든 상태 종류
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
    //플레이어가 가질 수 있는 모든 상태 개수
    public static int state_count = 9;
    //플레이어가 가질 수 있는 모든 상태들 배열
    public State<Player>[] _states;
    private StateManager<Player> _stateManager;
    /// <summary>
    /// Player 클래스 설정을 위한 Setup메소드, 최대 체력을 매개변수로 받고 base로 부모의 Setup메소드를 호출
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public override void Setup(float maxHp)
    {
        base.Setup(maxHp);
        
        //_states 초기화
        _states = new State<Player>[state_count];
        _states[(int)PlayerStates.IsGround] = new PlayerOwnedStates.IsGround();
        _states[(int)PlayerStates.IsAir] = new PlayerOwnedStates.IsAir();
        _states[(int)PlayerStates.IsJump] = new PlayerOwnedStates.IsJump();
        _states[(int)PlayerStates.IsWall] = new PlayerOwnedStates.IsWall();
        _states[(int)PlayerStates.IsDash] = new PlayerOwnedStates.IsDash();
        _states[(int)PlayerStates.IsMove] = new PlayerOwnedStates.IsMove();
        _states[(int)PlayerStates.IsStun] = new PlayerOwnedStates.IsStun();
        _states[(int)PlayerStates.IsAttacked] = new PlayerOwnedStates.IsAttacked();
        _states[(int)PlayerStates.IsAttacking] = new PlayerOwnedStates.IsAttacking();

        _stateManager = new StateManager<Player>();
        _stateManager.Setup(this,state_count,_states);
    }

    //부모의 추상 메소드를 구현, Entity_Manager의 Update에서 반복함
    public override void Updated()
    {
        //상태 매니저의 Execute실행
        _stateManager.Execute();

        //상태 추가 제거 테스트용
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddState(_states[0]);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            RemoveState(_states[0]);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddState(_states[1]);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveState(_states[1]);
        }
    }

    //상태 추가 메소드
    public void AddState(State<Player> newState)
    {
        _stateManager.AddState(newState);
    }
    
    //상태 제거 메소드
    public void RemoveState(State<Player> remState)
    {
        _stateManager.RemoveState(remState);
    }
}
