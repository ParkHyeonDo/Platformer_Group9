using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public int NextMove;
    public Transform WeaponTransform;
    private Vector2 boxSize = new Vector2(8, 3);
    public LayerMask targetLayer; // 감지할 레이어
    private MonsterAnimationController animationController;
    private Transform playerTransform;
    private bool isChasingPlayer;
    private float weaponScale = 1f;
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

        if (isChasingPlayer && playerTransform != null)
        {
            MoveTowardsPlayer();
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(NextMove, rb.velocity.y);

        Vector2 frontVec = new Vector2(rb.position.x + NextMove * 0.5f, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 3, LayerMask.GetMask("Player"));

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
            if (collider.gameObject.CompareTag("Player"))
            {
                playerTransform = collider.transform; // 플레이어의 트랜스폼 저장
                isChasingPlayer = true; // 플레이어 추적 시작
            }
        }
    }

    void MoveTowardsPlayer()
    {
        animationController.SetWalking(true); // 이동 애니메이션 시작
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * 1.2f * Time.deltaTime;
        spriteRenderer.flipX = direction.x > 0;
        Weaponpoint(false);
    }

    private void OnDrawGizmos()
    {
        // Gizmos를 사용하여 박스 범위를 시각적으로 표시
        Gizmos.color = Color.red; // 색상 설정
        Gizmos.DrawWireCube(transform.position, boxSize); // 박스 그리기
    }

    void Think()
    {
        NextMove = Random.Range(-1, 2);
        Invoke("Think", 3);

        if (NextMove != 0)
        {
            spriteRenderer.flipX = NextMove == 1;
            Weaponpoint(false);
        }
    }

    void Turn()
    {
        NextMove *= -1;
        spriteRenderer.flipX = NextMove == 1;
        Weaponpoint(false);
        CancelInvoke();
        Invoke("Think", 3);
    }
    private void Weaponpoint(bool leftVector)
    {
        if (!leftVector)
        {
            WeaponTransform.localScale = Vector3.one * weaponScale;
        }
        else
        {
            WeaponTransform.localScale = -Vector3.one * weaponScale;
        }
    }
}
