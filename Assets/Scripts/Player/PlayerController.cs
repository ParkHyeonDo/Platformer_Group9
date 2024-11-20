using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public LayerMask GroundMask;
    public LayerMask LadderMask;
    public LayerMask LadderTopMask;

    private CharacterStatHandler playerStat;
    private bool isAttack;
    private bool isGround;
    private bool isLadder;
    private bool isHit;

    private string isMoveTr = "isMove";
    private string isJumpTr = "isJump";
    private string isAttackTr = "isAttack";
    private string isLadderTr = "isLadder";
    private int isMoveAnim;
    private int isJumpAnim;
    private int isAttackAnim;
    private int isLadderAnim;

    private float playerGravity;
    private Rigidbody2D rb;
    private SpriteRenderer playerRenderer;
    public BoxCollider2D PlayerCollider;
    private Vector2 currentMove;
    private Vector2 targetVector;
    private Animator animator;
    private LadderClimb ladderClimb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        ladderClimb = GetComponent<LadderClimb>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        playerStat = GetComponent<CharacterStatHandler>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerGravity = rb.gravityScale;

        // 메모리 최적화
        isMoveAnim = Animator.StringToHash(isMoveTr);
        isJumpAnim = Animator.StringToHash(isJumpTr);
        isAttackAnim = Animator.StringToHash(isAttackTr);
        isLadderAnim = Animator.StringToHash(isLadderTr);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.down, Vector3.up*2f, Color.red);
        //Debug.DrawRay(transform.position, Vector3.up, Color.blue);
    }

    private void FixedUpdate()
    {
        if (!isLadder)
        {
            Move();
            PlayerCollider.enabled = true;
        }
        else 
        {
            Ladder();
            PlayerCollider.enabled = false;
        }
        
    }

    

    public void OnMove(InputAction.CallbackContext context) 
    {
         currentMove = context.ReadValue<Vector2>() ; 

        if (context.canceled) 
        {
            currentMove = Vector2.zero;
        }
    }

    public void Move() 
    {
        if (currentMove.x != 0)
        {
            if (!isAttack)
            {
                if (currentMove.x < 0) playerRenderer.flipX = true;
                else if (currentMove.x >= 0) playerRenderer.flipX = false;
                targetVector.x = currentMove.x * playerStat.PlayerCurrentStat.Speed ;
                targetVector.y = rb.velocity.y;
                rb.velocity = targetVector;
                animator.SetBool(isMoveAnim, true);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool(isMoveAnim, false);
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        
        if (context.phase == InputActionPhase.Started && IsGround()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * playerStat.PlayerCurrentStat.JumpForce, ForceMode2D.Impulse);
            animator.SetBool(isJumpAnim, true);
        }
    }

    private bool IsGround()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f , GroundMask)) return true;
        return false;
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
    
    }

    public void OnLadder(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && Physics2D.Raycast(transform.position, Vector3.down, 1f, LadderMask))
        {
            animator.speed = 1;
            rb.gravityScale = 0;
            isLadder = true;
            currentMove = context.ReadValue<Vector2>();
            /*if (context.ReadValue<Vector2>().y > 0 && !Physics2D.Raycast(transform.position, Vector3.up, 1f, LadderMask)) 
            {
                Debug.Log("언제 타 ?");
                rb.gravityScale = playerGravity;
                animator.SetBool(isLadderAnim, false);
                isLadder = false;
            }*/
        }
        else if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Canceled && Physics2D.Raycast(transform.position, Vector3.down, 0.5f, LadderMask))
        {
            animator.speed = 0;
            rb.gravityScale = 0;
            currentMove = Vector2.zero;
        } 
        else 
        {
            animator.speed = 1;
            rb.gravityScale = playerGravity;
            animator.SetBool(isLadderAnim, false);
            isLadder = false;
        }
    }

    private void Ladder()
    {
        
        targetVector.x = Vector2.zero.x;
        targetVector.y = currentMove.y * playerStat.PlayerCurrentStat.Speed;
        rb.velocity = targetVector;
        animator.SetBool(isLadderAnim, true);
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started && !isAttack) 
        {
            animator.SetBool(isAttackAnim, true);
            isAttack = true;
        }
    }

    public void OnDash(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started)
        {
            
            playerStat.PlayerCurrentStat.Speed *= 2f;

        }
        else if (context.phase == InputActionPhase.Canceled) 
        {
            
            playerStat.PlayerCurrentStat.Speed /= 2f;
        }
    }

    public void AttackFinished() 
    {
        animator.SetBool(isAttackAnim, false);
        isAttack = false;
    }

    public void JumpFinished() 
    {
        animator.SetBool(isJumpAnim, false);
    }
}
