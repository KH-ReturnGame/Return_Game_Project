using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;
    private Tilemap tilemap;
    public GameObject hi;


    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
        tilemap = GameObject.FindGameObjectWithTag("ground").GetComponent<Tilemap>();
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("바닥 닿음");
        if (other.CompareTag("ground")) 
        {
            _player.AddState(PlayerStates.IsGround);
        }
        if (other.CompareTag("wall"))
        {
            _player.AddState(PlayerStates.IsWall);
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
