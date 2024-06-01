using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;

    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("바닥 닿음");
        if ( other.gameObject.layer == 6 )
        {
            _player.AddState(_player._states[(int)PlayerStates.IsGround]);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("바닥 떨어짐");
        if (other.gameObject.layer == 6)
        {
            _player.RemoveState(_player._states[(int)PlayerStates.IsGround]);    
        }
    }
}
