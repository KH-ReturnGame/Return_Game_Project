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

    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("바닥 닿음");
        if (other.gameObject.layer == 6)
        {
            _player.AddState(_player._states[(int)PlayerStates.IsGround]);
            Debug.Log("바닥 닿음");
        }
        
        // 벽에 닿았을 때 벽타기 상태 설정
        if (other.gameObject.layer == 7)
        {
            _player.AddState(_player._states[(int)PlayerStates.IsWall]);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("바닥 떨어짐");
        if (other.gameObject.layer == 6)
        {
            _player.RemoveState(_player._states[(int)PlayerStates.IsGround]);
            Debug.Log("바닥 떨어짐");
        }
        

        
    }
}
