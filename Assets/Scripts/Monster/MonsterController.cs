using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    
    // 각각의 몬스터의 공격범위 
    private float attackDistanc = 1f;
    // 각각의 몬스터의 속도
    private float moveSpeed = 1.0f;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (target == null)
        {
            Debug.Log("tartget이 Null입니다.");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        LookAtTarget();
    }

    private void Move()
    {
        if (target == null) return;

        Vector2 dir = ((Vector2)target.position - rb.position).normalized;

        if (Vector2.Distance(transform.position, target.position) <= attackDistanc)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void LookAtTarget()
    {
        if (transform.position.x < target.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}
