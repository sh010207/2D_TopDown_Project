using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private readonly int IsRun = Animator.StringToHash("IsRun");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void MoveAnimation(bool isMove)
    {
        if (isMove)
        {
            _animator.SetInteger(IsRun, 1);
        }
        else
        {
            _animator.SetInteger(IsRun, 0);
        }
    }

    public void DeadAnimaiton(bool checkAnimation)
    {
        _animator.SetBool("IsDead", checkAnimation);
    }

    public void HitAnimation()
    {
        _animator.SetTrigger("IsHit");
    }

}
