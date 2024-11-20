using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("Think", 3);
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

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        Invoke("Think", 3);
        if (nextMove != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        { }
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
