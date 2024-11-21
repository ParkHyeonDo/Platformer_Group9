using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public int health;
    public int nextMove;
    private Vector2 boxSize = new Vector2(5, 3);
    public LayerMask targetLayer; // 감지할 레이어
    private MonsterAnimationController animationController;
    private Transform playerTransform;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<MonsterAnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 3);
    }

    private void Update()
    {
        DetectPlayer();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(nextMove, rb.velocity.y);

        Vector2 frontVec = new Vector2(rb.position.x + nextMove*0.5f, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 2, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void DetectPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, targetLayer);
        foreach (Collider2D collider in hitColliders)
        {
            // 각 콜라이더가 "Enemy" 태그를 가지고 있는지 확인
            if (collider.CompareTag("Player"))
            {
                // "Player" 태그가 있는 경우 처리 수행
                Debug.Log("적 감지됨: " + collider.name);
                // 여기에 추가적인 처리 로직을 작성할 수 있습니다.
            }
        }
    }
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
    private void OnDrawGizmos()
    {
        // Gizmos를 사용하여 박스 범위를 시각적으로 표시
        Gizmos.color = Color.red; // 색상 설정
        Gizmos.DrawWireCube(transform.position, boxSize); // 박스 그리기
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
        
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == -1;
        CancelInvoke();
        Invoke("Think",3);
    }
}
