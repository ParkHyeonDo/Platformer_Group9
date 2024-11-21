using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("IsWalking", isWalking);
    }

    public void SetDead(bool isDead)
    {
        animator.SetBool("IsDead", isDead);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("AttackTrigger");

    }
    public void TriggerHit()
    {
        animator.SetTrigger("HitTrigger");
    }
    public void TiggerCast()
    {
        animator.SetTrigger("CastTrigger");
    }
    public void SetAttack(bool isAttack)
    {
        animator.SetBool("IsAttack", isAttack);
    }
    
}
