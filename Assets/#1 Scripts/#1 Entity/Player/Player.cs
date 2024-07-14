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
    CanJump,
    CanDash,
    IsDashing,
    IsWall,
    //
    IsMove,
    IsFallAttacking,

}

/// <summary>
/// 플레이어 클래스
/// </summary>
/// <returns></returns>
public class Player : Entity
{
    //플레이어가 가질 수 있는 모든 상태 개수
    public static int state_count = Enum.GetValues(typeof(PlayerStates)).Length;
    //플레이어가 가질 수 있는 모든 상태들 배열
    public State<Player>[] _states;
    public StateManager<Player> _stateManager;

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
        _states[(int)PlayerStates.CanJump] = new PlayerOwnedStates.CanJump();
        _states[(int)PlayerStates.CanDash] = new PlayerOwnedStates.CanDash();
        _states[(int)PlayerStates.IsDashing] = new PlayerOwnedStates.IsDashing();
        _states[(int)PlayerStates.IsWall] = new PlayerOwnedStates.IsWall();
        _states[(int)PlayerStates.IsMove] = new PlayerOwnedStates.IsMove();
        _states[(int)PlayerStates.IsFallAttacking] = new PlayerOwnedStates.IsFallAttacking();

        _stateManager = new StateManager<Player>();
        _stateManager.Setup(this,state_count,_states);
    }
    
    //부모의 추상 메소드를 구현, Entity_Manager의 Update에서 반복함
    public override void Updated()
    {
        //상태 매니저의 Execute실행
        _stateManager.Execute();
    }

    //상태 추가 메소드
    public void AddState(PlayerStates ps)
    {
        State<Player> newState = _states[(int)ps];
        _stateManager.AddState(newState);
    }
    
    //상태 제거 메소드
    public void RemoveState(PlayerStates ps)
    {
        State<Player> remState = _states[(int)ps];
        _stateManager.RemoveState(remState);
    }
    //상태 있는지 체크
    public bool IsContainState(PlayerStates ps)
    {
        return _stateManager._currentState.Contains(_states[(int)ps]);
    }
}
