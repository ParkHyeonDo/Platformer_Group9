using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour
{
    public int health;
    public MonsterAnimationController animationController;
    public Rigidbody2D rb;
    public void TakeDamage(int damage)
    {
        health -= damage;
        animationController.TriggerHit();

        if (health <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("���� ���ظ� �Ծ����ϴ�. ���� ü��: " + health);
        }
    }

    private void Die()
    {
        animationController.SetDead(true);
        rb.velocity = Vector2.zero; // ���� �� ������ ���߱�
        GetComponent<Collider2D>().enabled = false; // �浹 ��Ȱ��ȭ
        this.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        Debug.Log("���� ����߽��ϴ�.");

        // 2�� �Ŀ� GameObject�� ����
        Destroy(gameObject, 2f);
    }
}