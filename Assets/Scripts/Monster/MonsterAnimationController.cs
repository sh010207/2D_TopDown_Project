using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void MoveAnimation(bool isMoving)
    {
        if(isMoving)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }

    public void HitAnimation()
    {
        animator.SetTrigger("IsHit");
    }

    public void DeadAnimation(bool isDeadCheck)
    {
        animator.SetBool("IsDead", isDeadCheck);
    }
}
