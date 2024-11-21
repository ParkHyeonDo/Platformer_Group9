using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public int nextMove;
    public Transform WeaponTransform;
    private Vector2 boxSize = new Vector2(5, 3);
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
        rb.velocity = new Vector2(nextMove, rb.velocity.y);

        Vector2 frontVec = new Vector2(rb.position.x + nextMove * 0.3f, rb.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, Vector3.down, 2, LayerMask.GetMask("Ground"));
        if (rayHit.collider == null)
        {
            Debug.Log("레이가 땅에 닿지 않음");
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
                Debug.Log("플레이어 인지! 추적 시작.");
            }
        }
    }

    void MoveTowardsPlayer()
    {
        animationController.SetWalking(true); // 이동 애니메이션 시작
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * 2 * Time.deltaTime;
        spriteRenderer.flipX = direction.x < 0;
        Weaponpoint(true);
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
        {
            spriteRenderer.flipX = nextMove == -1;
            Weaponpoint(true);
        }   
    }

    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == -1;
        Weaponpoint (true);
        CancelInvoke();
        Invoke("Think",3);
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
