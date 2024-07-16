using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : Weapon
{
    //기본 무기 설정
    private void Start()
    {
        //무기 데미지 30, 0에서 최대 과열정도까지 증가하는데 걸리는 시간 10초
        Setup(150,1f,40);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("hh");
            AddState(WeaponStates.IsAttackingKatana);
            IncreaseOverheatingDot();
        }
        if(Input.GetKey(KeyCode.P))
        {
            RemoveState(WeaponStates.IsAttackingKatana);
        }
    }
}