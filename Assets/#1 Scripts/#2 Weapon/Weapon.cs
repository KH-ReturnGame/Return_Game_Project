using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Weapon : MonoBehaviour
{
    //무기의 공격력
    protected float Damage;
    //무기가 나노머신의 과열정도를 0에서 최대까지 몇초만에 채우는지
    protected float OverheatingTime;
    
    //웨폰 매니저와 연결을 위해 저장
    [SerializeField]
    private Weapon_Manager _weaponManager;

    public void Setup(float damage, float overheatingTime)
    {
        //기본 변수 설정
        Damage = damage;
        OverheatingTime = overheatingTime;
    }
    
    public void IncreaseOverheating()
    {
        
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
}