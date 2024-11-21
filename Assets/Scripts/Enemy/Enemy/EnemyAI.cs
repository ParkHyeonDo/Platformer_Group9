using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public int nextMove;
    public Transform WeaponTransform;
    private Vector2 boxSize = new Vector2(5, 3);
    public LayerMask targetLayer; // ������ ���̾�
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
            Debug.Log("���̰� ���� ���� ����");
            Turn();
        }
    }
    void DetectPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, targetLayer);
        foreach (Collider2D collider in hitColliders)
        {
            // �� �ݶ��̴��� "Enemy" �±׸� ������ �ִ��� Ȯ��
            if (collider.gameObject.CompareTag("Player"))
            {
                playerTransform = collider.transform; // �÷��̾��� Ʈ������ ����
                isChasingPlayer = true; // �÷��̾� ���� ����
                Debug.Log("�÷��̾� ����! ���� ����.");
            }
        }
    }

    void MoveTowardsPlayer()
    {
        animationController.SetWalking(true); // �̵� �ִϸ��̼� ����
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * 2 * Time.deltaTime;
        spriteRenderer.flipX = direction.x < 0;
        Weaponpoint(true);
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
