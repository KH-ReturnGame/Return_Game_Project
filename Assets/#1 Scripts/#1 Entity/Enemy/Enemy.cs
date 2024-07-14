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
    //에너미가 가질 수 있는 모든 상태 개수
    public static int state_count = 12;
    //에너미가 가질 수 있는 모든 상태들
    public State<Enemy>[] _states;
    public StateManager<Enemy> _stateManager;

    /// <summary>
    /// Enemy 클래스 설정을 위한 Setup메소드, 최대 체력을 매개변수로 받고 base로 부모의 Setup메소드를 호출
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public override void Setup(float maxHp)
    {
        base.Setup(maxHp);
        
        //_states 초기화
        _states = new State<Enemy>[state_count];
        _states[(int)EnemyStates.IsGround] = new EnemyOwnedStates.IsGround();
        _states[(int)EnemyStates.IsAir] = new EnemyOwnedStates.IsAir();
        _states[(int)EnemyStates.IsJump] = new EnemyOwnedStates.IsJump();
        _states[(int)EnemyStates.IsWall] = new EnemyOwnedStates.IsWall();
        _states[(int)EnemyStates.IsMove] = new EnemyOwnedStates.IsMove();
        _states[(int)EnemyStates.IsStun] = new EnemyOwnedStates.IsStun();
        _states[(int)EnemyStates.IsAttacked] = new EnemyOwnedStates.IsAttacked();
        _states[(int)EnemyStates.IsAttacking] = new EnemyOwnedStates.IsAttacking();
        _states[(int)EnemyStates.IsDetect] = new EnemyOwnedStates.IsDetect();
        _states[(int)EnemyStates.IsDie] = new EnemyOwnedStates.IsDie();
        _states[(int)EnemyStates.IsCool] = new EnemyOwnedStates.IsCool();
        
        _stateManager = new StateManager<Enemy>();
        _stateManager.Setup(this,state_count,_states);
    }

    //부모의 추상 메소드를 구현, Entity_Manager의 Update에서 반복함
    public override void Updated()
    {
        if (IsContainState(EnemyStates.IsDie))
        {
            return;
        }
        //상태 매니저의 Execute실행
        _stateManager.Execute();
    }

    //상태 추가 메소드
    public void AddState(EnemyStates ps)
    {
        State<Enemy> newState = _states[(int)ps];
        _stateManager.AddState(newState);
    }
    
    //상태 제거 메소드
    public void RemoveState(EnemyStates ps)
    {
        State<Enemy> remState = _states[(int)ps];
        _stateManager.RemoveState(remState);
    }
    //상태 있는지 체크
    public bool IsContainState(EnemyStates ps)
    {
        return _stateManager._currentState.Contains(_states[(int)ps]);
    }

}
