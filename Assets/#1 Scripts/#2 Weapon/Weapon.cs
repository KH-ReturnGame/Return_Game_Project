using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //무기의 공격력
    protected float Damage;
    //무기가 나노머신의 과열정도를 0에서 최대까지 몇초만에 채우는지
    protected float OverheatingTime;

    public void Setup(float damage, float overheatingTime)
    {
        Damage = damage;
        OverheatingTime = overheatingTime;
    }

    public void IncreaseOverheating()
    {
        
    }
}