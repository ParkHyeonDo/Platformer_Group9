using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public int health;
    public int nextMove;
    private Vector2 boxSize = new Vector2(5, 3);
    public LayerMask targetLayer; // ������ ���̾�
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
            // �� �ݶ��̴��� "Enemy" �±׸� ������ �ִ��� Ȯ��
            if (collider.CompareTag("Player"))
            {
                // "Player" �±װ� �ִ� ��� ó�� ����
                Debug.Log("�� ������: " + collider.name);
                // ���⿡ �߰����� ó�� ������ �ۼ��� �� �ֽ��ϴ�.
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
    private void OnDrawGizmos()
    {
        // Gizmos�� ����Ͽ� �ڽ� ������ �ð������� ǥ��
        Gizmos.color = Color.red; // ���� ����
        Gizmos.DrawWireCube(transform.position, boxSize); // �ڽ� �׸���
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
