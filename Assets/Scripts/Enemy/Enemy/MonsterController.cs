using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 몬스터의 이동 속도
    private Transform player; // 플레이어의 트랜스폼
    private MonsterAnimationController m_animator; // 애니메이터 컴포넌트
    private SpriteRenderer characterRenderer;
    private bool isChasingPlayer;

    void Start()
    {
        m_animator = GetComponent<MonsterAnimationController>(); // 애니메이터 컴포넌트 가져오기
        characterRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 가져오기
    }

    void Update()
    {
        if (isChasingPlayer && player != null)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        m_animator.SetWalking(true); // 이동 애니메이션 시작
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        characterRenderer.flipX = direction.x < 0;
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform; // 플레이어의 트랜스폼 저장
            isChasingPlayer = true; // 플레이어 추적 시작
            Debug.Log("플레이어 인지! 추적 시작.");
        }
    }
}