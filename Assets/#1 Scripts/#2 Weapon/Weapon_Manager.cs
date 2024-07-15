using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//무기가 가질 수 있는 모든 상태 종류
public enum WeaponStates
{
    CanDecrease,
    IsReloadingRifle,
    IsShootingRifle
}

public class Weapon_Manager : MonoBehaviour
{
    //무기 과열관련 변수
    private static float MaxOverheating = 200f;
    public float Overheating=200f;
    private float DecreaseTime = 15;
    private Slider OverheatSlider;
    
    //무기가 가질 수 있는 모든 상태 개수
    public static int state_count = Enum.GetValues(typeof(WeaponStates)).Length;
    //플레이어가 가질 수 있는 모든 상태들 배열
    public State<Weapon_Manager>[] _states;
    public StateManager<Weapon_Manager> _stateManager;

    public void Start()
    {
        //state 초기화
        _states = new State<Weapon_Manager>[state_count];
        _states[(int)WeaponStates.CanDecrease] = new WeaponOwnedStates.CanDecrease();
        _states[(int)WeaponStates.IsReloadingRifle] = new WeaponOwnedStates.IsReloadingRifle();
        _states[(int)WeaponStates.IsShootingRifle] = new WeaponOwnedStates.IsShootingRifle();
        
        _stateManager = new StateManager<Weapon_Manager>();
        _stateManager.Setup(this,state_count,_states);
        
        //슬라이더 가져오기
        OverheatSlider = transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();
        
        //과열 감소 시작
        StartCoroutine(DecreaseOverheating());
    }
    
    public void Update()
    {
        //상태 매니저의 Execute실행
        _stateManager.Execute();
        
        
    }
    
    //상태 추가 메소드
    public void AddState(WeaponStates ps)
    {
        State<Weapon_Manager> newState = _states[(int)ps];
        _stateManager.AddState(newState);
    }
    
    //상태 제거 메소드
    public void RemoveState(WeaponStates ps)
    {
        State<Weapon_Manager> remState = _states[(int)ps];
        _stateManager.RemoveState(remState);
    }
    
    //상태 있는지 체크
    public bool IsContainState(WeaponStates ps)
    {
        return _stateManager._currentState.Contains(_states[(int)ps]);
    }

    //과열 자동 감소
    private IEnumerator DecreaseOverheating()
    {
        yield return new WaitUntil(() => IsContainState(WeaponStates.CanDecrease));
        if (Overheating > 0 && Overheating <= MaxOverheating)
        {
            Overheating--;
            OverheatSlider.value = Overheating / MaxOverheating;
        }

        yield return new WaitForSeconds(DecreaseTime/MaxOverheating);

        StartCoroutine(DecreaseOverheating());
    }
    //과열 증가
    public void IncreaseOverheating()
    {
        
    }
}