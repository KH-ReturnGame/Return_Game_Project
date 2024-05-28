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
    public float _jumpForce = 5f;


    /*
     - 무한 점프 방지 관련 변수
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    private bool isGrounded;
    */

    private bool _canDash = true;
    private bool _isDashing;
    private float _dashPower = 24f;
    private float _dashTime = 0.2f;
    private float _dashCooldown = 1f;

    [SerializeField] private TrailRenderer tr;


    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
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
         -바닥 체크가 가능해지면 사용하는 코드
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        */

        // 대시 실행
        if (_isDashing)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(Dash());
        }
    }

    //0.02초마다 실행
    private void FixedUpdate()
    {
        //움직임 적용
        ApplyMovement();

        //대시
        if (_isDashing)
        {
            return;
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
        _canDash = false;
        _isDashing = true;
        float originalGravity = _playerRigidbody.gravityScale;
        _playerRigidbody.gravityScale = 0f;
        _playerRigidbody.velocity = new Vector2(transform.localScale.x * _dashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(_dashTime);
        tr.emitting = false;
        _playerRigidbody.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashCooldown);
        _canDash = true;
    }
}