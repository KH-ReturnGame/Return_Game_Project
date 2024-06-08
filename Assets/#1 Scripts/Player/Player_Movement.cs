using System.Collections;
using UnityEngine;
using System;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
/// <returns></returns>
public class Player_Movement : MonoBehaviour
{
    //플레이어
    private Rigidbody2D _playerRigidbody;
    private Player _player;
    SpriteRenderer spriteRenderer;
    
    //기본 좌우, 점프
    private float _recentDirection = 1;
    [SerializeField]
    private float _movementSpeed = 10.00f;
    private float _movementInputDirection;
    public float _jumpForce = 15f;    
    
    //대시
    private float _dashPower = 24f;     // 대시 힘 관리
    private float _dashTime = 0.2f;     // 대시 작동 시간 
    private float _dashCooldown = 1f;   // 대시 쿨타임
    private float originalGravity;      // 플레이어 원래 중력
    [SerializeField] private TrailRenderer tr;

    //검 애니메이션
    private Animator _animator;
    public GameObject sword;

    // 벽타기 관련 변수
    public LayerMask wallLayer;
    public float wallCheckDistance = 0.5f;
    public float wallSlideSpeed = 2f;
    public float wallJumpForce = 10f;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");


    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player.AddState(PlayerStates.CanDash);
        originalGravity = _playerRigidbody.gravityScale;
        _animator = sword.GetComponent<Animator>();
    }

    //매 프레임 실행
    void Update()
    {
        //가로 입력 체크하기 ----------------------------------------
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (_movementInputDirection != 0)
        {
            _recentDirection = _movementInputDirection;
        }
        // 방향전환
        if (_recentDirection != 0)
        {
            spriteRenderer.flipX = _recentDirection == 1;
        }


        //점프 코드 ----------------------------------------
        if (_player.IsContainState(PlayerStates.IsDashing))
        {
            if ( _player.IsContainState(PlayerStates.IsGround) && 
                 Input.GetButtonDown("Jump"))
            {
                _playerRigidbody.gravityScale = originalGravity;    // 중력 값 되돌림
                Jump();
            }
        }
        else
        {
            if ( _player.IsContainState(PlayerStates.IsGround) && 
                 Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
        
        // 대시 실행 ----------------------------------------
        if (!_player.IsContainState(PlayerStates.IsDashing) && 
            Input.GetKeyDown(KeyCode.LeftShift) && 
            _player.IsContainState(PlayerStates.CanDash)
           )
        {
            StartCoroutine(Dash());
        }
        

        // 벽슬라이드 로직 ----------------------------------------
        if (_player.IsContainState(PlayerStates.IsWall) && !_player.IsContainState(PlayerStates.IsGround) && _movementInputDirection != 0)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, -wallSlideSpeed);
        }
        // 벽타기 취소
        else _player.RemoveState(PlayerStates.IsWall);
        
        
        //칼 애니메이션 테스트 ----------------------------------------
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            _animator.SetBool("open_sword",!_animator.GetBool("open_sword"));
        }
    }

    
    //0.02초마다 실행  ----------------------------------------
    private void FixedUpdate()
    {
        //움직임 적용
        if (!_player.IsContainState(PlayerStates.IsDashing))
        {
            ApplyMovement();
        }
    }

    private void ApplyMovement()
    {
        _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        //Debug.Log("jump");
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, 0);
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _jumpForce);
    }

    private IEnumerator Dash()
    {
        //Debug.Log("dash");
        _player.RemoveState(PlayerStates.CanDash);
        _player.AddState(PlayerStates.IsDashing);
        _playerRigidbody.gravityScale = 0f; // 중력 0으로 바꿔 대시중에 영향 없게 설정 
        _playerRigidbody.velocity = Vector2.zero;
        _playerRigidbody.velocity = new Vector2(_recentDirection * _dashPower, 0);      // 대시 적용
        tr.emitting = true;     // 이펙트 적용
        yield return new WaitForSeconds(_dashTime);
        tr.emitting = false;
        _playerRigidbody.gravityScale = originalGravity;    // 중력 값 되돌림
        _player.RemoveState(PlayerStates.IsDashing);
        yield return new WaitForSeconds(_dashCooldown);
        _player.AddState(PlayerStates.CanDash);
    }
}
