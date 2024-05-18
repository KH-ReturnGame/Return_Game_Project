using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private Rigidbody2D player_rigidbody;
    private float movementInputDirection;
    private float movementSpeed = 10.00f;
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
    }

    private void ApplyMovement()
    {
        player_rigidbody.velocity = new Vector2(movementInputDirection * movementSpeed, player_rigidbody.velocity.y);
    }
}
