using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // ������ �̵� �ӵ�
    private Transform player; // �÷��̾��� Ʈ������
    private MonsterAnimationController m_animator; // �ִϸ����� ������Ʈ
    private SpriteRenderer characterRenderer;
    private bool isChasingPlayer;

    void Start()
    {
        m_animator = GetComponent<MonsterAnimationController>(); // �ִϸ����� ������Ʈ ��������
        characterRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ ��������
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
        m_animator.SetWalking(true); // �̵� �ִϸ��̼� ����
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        characterRenderer.flipX = direction.x < 0;
    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform; // �÷��̾��� Ʈ������ ����
            isChasingPlayer = true; // �÷��̾� ���� ����
            Debug.Log("�÷��̾� ����! ���� ����.");
        }
    }
}