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
            Debug.Log("적이 피해를 입었습니다. 남은 체력: " + health);
        }
    }

    private void Die()
    {
        animationController.SetDead(true);
        rb.velocity = Vector2.zero; // 죽을 때 움직임 멈추기
        GetComponent<Collider2D>().enabled = false; // 충돌 비활성화
        this.enabled = false; // 스크립트 비활성화
        Debug.Log("적이 사망했습니다.");

        // 2초 후에 GameObject를 제거
        Destroy(gameObject, 2f);
    }
}