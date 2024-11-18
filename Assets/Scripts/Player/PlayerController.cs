using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpPower;

    private bool isIdle;
    private bool isAttack;
    private bool isGround;
    private bool isHit;
    private Rigidbody2D rb;
    private SpriteRenderer playerRenderer;
    private Vector2 currentMove;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            //animator.SetBool("isJump", false);
        }
        else 
        {
            isGround = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Ground"));
        }
        
        
    }

    private void FixedUpdate()
    {
        if (currentMove.x != 0)
        {
            if (!isAttack)
            {
                rb.velocity = new Vector2(currentMove.x, rb.velocity.y);
                animator.SetBool("isMove", true);
            }
        }
        else 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isMove", false);
        }
        
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
         currentMove = context.ReadValue<Vector2>() * moveSpeed; 

        if (context.canceled) 
        {
            currentMove = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        
        if (context.phase == InputActionPhase.Started && isGround) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
        }
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
    
    }

    public void OnLadder(InputAction.CallbackContext context) 
    {
    
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started && !isAttack) 
        {
            animator.SetBool("isAttack", true);
            isAttack = true;
        }
    }

    public void AttackFinished() 
    {
        animator.SetBool("isAttack", false);
        isAttack = false;
    }
}
