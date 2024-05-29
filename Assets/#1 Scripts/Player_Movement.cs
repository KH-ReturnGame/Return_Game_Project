using System.Collections;
using System.Collections.Generic;
using PlayerOwnedStates;
using UnityEditor.VersionControl;
using UnityEngine;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
/// <returns></returns>
public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D _playerRigidbody;
    private float _movementInputDirection;
    private float _movementSpeed = 10.00f;
    private Player _player;

    public float _jumpForce = 5f;       // 점프 힘 관리     
    /*
     - 무한 점프 방지 관련 변수
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    private bool isGrounded;
    */
    private float _dashPower = 24f;     // 대시 힘 관리
    private float _dashTime = 0.2f;     // 대시 작동 시간 
    private float _dashCooldown = 1f;   // 대시 쿨타임

    [SerializeField] private TrailRenderer tr;


    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        _player.AddState(_player._states[(int)PlayerStates.CanDash]);
    }

    //매 프레임 실행
    void Update()
    {
        //바닥 체크하기
        // isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, platform);

        //입력 체크하기
        CheckInput();

        // 점프 실행
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        /*
         //바닥 체크가 가능해지면 사용하는 코드
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        */

        // 대시 실행
        if (!_player._stateManager._currentState.Contains(_player._states[(int)PlayerStates.IsDashing]) && 
            Input.GetKeyDown(KeyCode.LeftShift) && 
            _player._stateManager._currentState.Contains(_player._states[(int)PlayerStates.CanDash]) &&
            _movementInputDirection != 0
            )
        {
            StartCoroutine(Dash());
        }

    }

    //0.02초마다 실행
    private void FixedUpdate()
    {
        //움직임 적용
        if (!_player._stateManager._currentState.Contains(_player._states[(int)PlayerStates.IsDashing]))
        {
            ApplyMovement();
        }
    }

    private void CheckInput()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
    }

    private void ApplyMovement()
    {
        _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
    }

    private void Jump()
    {
        _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
    }

    private IEnumerator Dash()
    {
        _player.RemoveState(_player._states[(int)PlayerStates.CanDash]);
        _player.AddState(_player._states[(int)PlayerStates.IsDashing]);
        float originalGravity = _playerRigidbody.gravityScale;      // 플레이어 원래 중력 저장
        _playerRigidbody.gravityScale = 0f;     // 중력 0으로 바꿔 대시중에 영향 없게 설정 
        _playerRigidbody.velocity = new Vector2(_movementInputDirection*_dashPower, 0);      // 대시 적용
        tr.emitting = true;     // 이펙트 적용
        yield return new WaitForSeconds(_dashTime);
        tr.emitting = false;
        _playerRigidbody.gravityScale = originalGravity;    // 중력 값 되돌림
        _player.RemoveState(_player._states[(int)PlayerStates.IsDashing]);
        yield return new WaitForSeconds(_dashCooldown);
        _player.AddState(_player._states[(int)PlayerStates.CanDash]);
    }
}