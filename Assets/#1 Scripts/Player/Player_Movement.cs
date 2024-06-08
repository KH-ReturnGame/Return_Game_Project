using System.Collections;
using UnityEngine;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
/// <returns></returns>
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private float _movementInputDirection;
    private float _recentDirection = 1;
    [SerializeField]
    private float _movementSpeed = 10.00f;
    private Player _player;
    SpriteRenderer spriteRenderer;

    public float _jumpForce = 5f;    
    
    private float _dashPower = 24f;     // 대시 힘 관리
    private float _dashTime = 0.2f;     // 대시 작동 시간 
    private float _dashCooldown = 1f;   // 대시 쿨타임
    private float _downJumpDuration = 0.4f;
    private float originalGravity;      // 플레이어 원래 중력

    [SerializeField] private TrailRenderer tr;

    private Animator _animator;
    public GameObject sword;
    
    // 벽타기 관련 변수
    public LayerMask wallLayer;
    public float wallCheckDistance = 0.5f;
    public float wallSlideSpeed = 2f;
    public float wallJumpForce = 10f;
   
    private Collider2D _playerCollider;
    
    private bool _isFallAttacking = false; // 낙하 공격 여부
    private float _fallAttackSpeed = 44f; // 낙하 공격 
    
    public ParticleSystem fallImpactParticleSystem;

    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<Collider2D>();
        _player = GetComponent<Player>();
        _player.AddState(PlayerStates.CanDash);
        originalGravity = _playerRigidbody.gravityScale;
        _animator = sword.GetComponent<Animator>();
    }

    //매 프레임 실행
    void Update()
    {
        //입력 체크하기
        CheckInput();


        //바닥 체크가 가능해지면 사용하는 코드
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

        // 벽타기 로직
        if (_player._stateManager._currentState.Contains(_player._states[(int)PlayerStates.IsWall]) && !_player._stateManager._currentState.Contains(_player._states[(int)PlayerStates.IsGround]) && _movementInputDirection != 0)
        {
            WallSlide();
        }
        // 벽타기 취소
        else _player.RemoveState(PlayerStates.IsWall);
        
        // 06-01 추가 ( 아래점프 실행 ) 
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetButtonDown("Jump"))
        {
            StartCoroutine(DownJump());
            _playerRigidbody.AddForce(Vector2.down * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("HojinByulGok");
        }
        else if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(DownJump());
            _playerRigidbody.AddForce(Vector2.down * _jumpForce, ForceMode2D.Impulse);
            Debug.Log("HojinByulGok");
        }
        
        // 낙하 공격 실행
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftControl) && !_isFallAttacking && _playerRigidbody.velocity.y > 0)
        {
            FallAttack();
        }

        // 대시 실행
        if (!_player.IsContainState(PlayerStates.IsDashing) && 
            Input.GetKeyDown(KeyCode.LeftShift) && 
            _player.IsContainState(PlayerStates.CanDash)
            )
        {
            StartCoroutine(Dash());
        }

        // 방향전환
        if (_recentDirection != 0)
        {
            spriteRenderer.flipX = _recentDirection == 1;
        }
        //칼 애니메이션 테스트
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            _animator.SetBool("open_sword",!_animator.GetBool("open_sword"));
        }
    }

    //0.02초마다 실행
    private void FixedUpdate()
    {
        //움직임 적용
        if (!_player.IsContainState(PlayerStates.IsDashing))
        {
            ApplyMovement();
        }
        // 낙하 공격 종료 체크
        if (_isFallAttacking && _playerRigidbody.velocity.y == 0)
        {
            _isFallAttacking = false;
            TriggerImpactEffect(); // 충격파 이펙트 트리거
        }
    }

    private void CheckInput()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
        if (_movementInputDirection != 0)
        {
            _recentDirection = _movementInputDirection;
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
    
    //06-01 추가
    private IEnumerator DownJump()
    {
        _playerCollider.enabled = false; // 충돌 비활성화
        yield return new WaitForSeconds(_downJumpDuration);
        _playerCollider.enabled = true; // 충돌 다시 활성화
    }
    
    private void FallAttack()
    {
        _isFallAttacking = true;
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, -_fallAttackSpeed);
    }

    private void TriggerImpactEffect()
    {
        fallImpactParticleSystem.transform.position = transform.position; // 이펙트 위치 설정
        fallImpactParticleSystem.Play(); // Particle System 재생
        StartCoroutine(StopParticleSystemAfterTime(fallImpactParticleSystem, 1f)); // 1초 후 이펙트 중지
    }

    private IEnumerator StopParticleSystemAfterTime(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);
        particleSystem.Stop();
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



    private void WallSlide()
    {
        _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, -wallSlideSpeed);
    }
}
