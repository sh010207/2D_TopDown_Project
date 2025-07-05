using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerAnimationController animationController;

    private Vector2 lookInput;
    private Vector2 moveDireaction;



    // 나중에 변경
    private readonly float moveSpeed = 2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animationController = GetComponentInChildren<PlayerAnimationController>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Look();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDireaction = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        rb.velocity = moveDireaction.normalized * moveSpeed;
        if (moveDireaction != Vector2.zero)
        {
            animationController.MoveAnimation(true);
        }
        else
        {
            animationController.MoveAnimation(false);
        }
    }

    private void Look()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(lookInput);
        mousePos.z = 0;

        if (mousePos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
