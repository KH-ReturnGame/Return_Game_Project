using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;
    
    private const float RAY_DISTANCE = 3f;
    private RaycastHit2D slopeHit;
    private int groundLayer;
    private float maxSlopeAngle = 45f;
    
    private Tilemap tilemap;
    public GameObject hi;

    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
        groundLayer = 1 << LayerMask.NameToLayer("platform");
        Debug.Log(groundLayer);
        tilemap = GameObject.FindGameObjectWithTag("ground").GetComponent<Tilemap>();
    }

    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("바닥 닿음");
        if ( other.gameObject.layer == 6 )
        {
            _player.AddState(_player._states[(int)PlayerStates.IsGround]);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("바닥 떨어짐");
        if (other.gameObject.layer == 6)
        {
            _player.RemoveState(_player._states[(int)PlayerStates.IsGround]);    
        }
    }
}
