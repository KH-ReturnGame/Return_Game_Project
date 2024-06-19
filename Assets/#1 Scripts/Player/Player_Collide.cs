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
            Debug.Log("바닥 닿음");
        }
        if (other.CompareTag("wall"))
        {
            _player.AddState(PlayerStates.IsWall);
            Debug.Log("벽 붙은 상태임");
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("바닥 떨어짐");
        if (other.CompareTag("ground"))
        {   
            Debug.Log("바닥 떨어짐");
            _player.RemoveState(PlayerStates.IsGround);    
        }
        if(!other.CompareTag("wall"))
        {
            _player.RemoveState(PlayerStates.IsWall);
            Debug.Log("벽 안붙음");
        }

        
    }
}
