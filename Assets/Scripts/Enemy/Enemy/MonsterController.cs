using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 몬스터의 이동 속도
    public float attackRange = 1.5f; // 공격 범위
    public float attackCooldown = 1.0f; // 공격 쿨다운 시간
    private float lastAttackTime = 0f; // 마지막 공격 시간

    private Transform player; // 플레이어의 트랜스폼
    private Animator animator; // 애니메이터 컴포넌트
    private SpriteRenderer characterRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 찾기
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        characterRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 가져오기
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("IsWalking", true); // 이동 애니메이션 시작
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        characterRenderer.flipX = direction.x < 0;
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            animator.SetBool("IsAttacking", true); // 공격 애니메이션 실행
            lastAttackTime = Time.time; // 마지막 공격 시간 업데이트
            Debug.Log("몬스터가 공격했습니다!");
            animator.SetBool("IsAttacking", false);
        }
    }
}