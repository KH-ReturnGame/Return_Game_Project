using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    //기본 무기 설정
    private void Start()
    {
        Setup(30,10);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("hi");
            AddState(WeaponStates.IsShootingRifle);
        }
        else
        {
            RemoveState(WeaponStates.IsShootingRifle);
        }
    }
}