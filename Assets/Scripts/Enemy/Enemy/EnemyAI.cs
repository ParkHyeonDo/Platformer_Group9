using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 boxSize = Vector3.right;
    public LayerMask targetLayer; // 감지할 레이어
    private MonsterAnimationController animationController;


    SpriteRenderer spriteRenderer;
    public int nextMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animationController = GetComponent<MonsterAnimationController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 3);
    }

    private void Update()
    {
        DetectUnits();
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
    void DetectUnits()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, targetLayer);
        Debug.DrawRay(transform.position, boxSize,Color.red);
        Collider2D[] hitcolliders;
        if(spriteRenderer.flipX == true)
        {
            hitColliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, targetLayer);
        }
        else
        {
            hitColliders = Physics2D.OverlapBoxAll(transform.position, -boxSize, 0f, targetLayer);
        }
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
