using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private float Max_Hp;
    private float Current_Hp;

    void RecoveryHp(float Hp)
    {
        if (Current_Hp + Hp > Max_Hp)
        {
            Debug.Log("cant recovery");
            Current_Hp = Max_Hp;
        }
        else
        {
            Current_Hp += Hp;
        }
    }

    void TakeDamage(float Hp)
    {
        if (Current_Hp - Hp < 0)
        {
            Debug.Log("gg");
            Current_Hp = 0;
        }
        Current_Hp -= Hp;
    }
}
