using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // ������ �̵� �ӵ�
    public float attackRange = 1.5f; // ���� ����
    public float attackCooldown = 1.0f; // ���� ��ٿ� �ð�
    private float lastAttackTime = 0f; // ������ ���� �ð�

    private Transform player; // �÷��̾��� Ʈ������
    private Animator animator; // �ִϸ����� ������Ʈ
    private SpriteRenderer characterRenderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾� ã��
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
        characterRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ ��������
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
        animator.SetBool("IsWalking", true); // �̵� �ִϸ��̼� ����
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        characterRenderer.flipX = direction.x < 0;
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            animator.SetBool("IsAttacking", true); // ���� �ִϸ��̼� ����
            lastAttackTime = Time.time; // ������ ���� �ð� ������Ʈ
            Debug.Log("���Ͱ� �����߽��ϴ�!");
            animator.SetBool("IsAttacking", false);
        }
    }
}