using System;
using UnityEngine.Tilemaps;
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
        //Debug.Log("바닥 닿음");
        if (other.CompareTag("ground")) 
        {
            _player.AddState(PlayerStates.IsGround);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("바닥 떨어짐");
        if (other.CompareTag("ground"))
        {
            _player.RemoveState(PlayerStates.IsGround);    
        }
        

        
    }
}
