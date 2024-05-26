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
    
    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }
    
    //매 프레임 실행
    void Update()
    {
        //입력 체크하기
        CheckInput();
    }

    //0.02초마다 실행
    private void FixedUpdate()
    {
        //움직임 적용
        ApplyMovement();
    }

    private void CheckInput()
    {
        _movementInputDirection = Input.GetAxisRaw("Horizontal");
    }

    private void ApplyMovement()
    {
        _playerRigidbody.velocity = new Vector2(_movementInputDirection * _movementSpeed, _playerRigidbody.velocity.y);
    }
}
