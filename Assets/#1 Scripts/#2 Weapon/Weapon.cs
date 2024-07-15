using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Weapon : MonoBehaviour
{
    //무기의 공격력
    protected float Damage;
    //무기가 나노머신의 과열정도를 0에서 최대까지 몇초만에 채우는지 (연속적 증가)
    //무기가 몇초에 한번 증가시키는지 (이산적 증가)
    protected float OverheatingTime;
    //무기가 어느정도를 증가시키는지 (이산적 증가)
    protected float IncreaseAmount;
    
    
    //웨폰 매니저와 연결을 위해 저장
    [SerializeField]
    private Weapon_Manager _weaponManager;
    
    //증가 코루틴들
    private Coroutine _increaseCoroutineContinuous;
    //private Coroutine _increaseCoroutineDot;
    private Coroutine _increaseCoroutineDiscrete;

    public void Setup(float damage, float overheatingTime)
    {
        //기본 변수 설정
        Damage = damage;
        OverheatingTime = overheatingTime;
    }
    public void Setup(float damage, float overheatingTime, float increaseAmount)
    {
        //기본 변수 설정
        Damage = damage;
        OverheatingTime = overheatingTime;
        IncreaseAmount = increaseAmount;
    }

    protected void AddState(WeaponStates ps)
    {
        _weaponManager.AddState(ps);
    }
    protected void RemoveState(WeaponStates ps)
    {
        _weaponManager.RemoveState(ps);
    }
    protected bool IsContainState(WeaponStates ps)
    {
        return _weaponManager.IsContainState(ps);
    }

    protected void IncreaseOverheatingContinuous()
    {
        if (_increaseCoroutineContinuous == null)
        {
            _increaseCoroutineContinuous = StartCoroutine(_weaponManager.IncreaseOverheatingContinuous(OverheatingTime));
        }
    }
    protected void IncreaseOverheatingDot()
    {
        if (IsContainState(WeaponStates.CanIncreaseDot))
        {
            RemoveState(WeaponStates.CanIncreaseDot);
            StartCoroutine(_weaponManager.IncreaseOverheatingDot(IncreaseAmount,OverheatingTime));
        }
        
    }
    protected void IncreaseOverheatingDiscrete()
    {
        if (_increaseCoroutineDiscrete == null)
        {
            _increaseCoroutineDiscrete = StartCoroutine(_weaponManager.IncreaseOverheatingDiscrete(IncreaseAmount,OverheatingTime));
        }
    }
}