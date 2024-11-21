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
    public LayerMask DoorMask;
    public LayerMask BoxMask;
    public GameObject WeaponPosition;
    [HideInInspector] public CapsuleCollider2D PlayerCollider;

    [HideInInspector] public bool IsAttack;

    private bool isGround;
    private bool isLadder;
    private bool isDash;
    private bool isHit;
    private float playerGravity;
    private float weaponScale=1f;

    private Rigidbody2D rb;
    private SpriteRenderer playerRenderer;
    private Vector2 currentMove;
    private Vector2 targetVector;
    private LadderClimb ladderClimb;
    
    private Transform vectorWeaponTransform;

    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip attackClip;
    [SerializeField] private AudioClip dashClip;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        ladderClimb = GetComponent<LadderClimb>();
        PlayerCollider = GetComponent<CapsuleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerGravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.down * 0.5f, Vector3.down*0.2f, Color.red);
    }

    private void FixedUpdate()
    {
        if (!isLadder && !isDash )
        {
            Move();
            PlayerCollider.enabled = true;
        }
        else if(isLadder)
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
            if (!IsAttack)
            {
                if (currentMove.x < 0) 
                {
                    playerRenderer.flipX = true;
                    WeaponFlip(true);
                }
                else if (currentMove.x >= 0)
                {
                    playerRenderer.flipX = false;
                    WeaponFlip(false);
                }
                targetVector.x = currentMove.x * GameManager.Instance.Player.Stat.CharacterCurrentStat.Speed ;
                targetVector.y = rb.velocity.y;
                rb.velocity = targetVector;
                GameManager.Instance.Player.PlayerAnim.MoveAnimStart();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            GameManager.Instance.Player.PlayerAnim.MoveAnimFinish();
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        
        if (context.phase == InputActionPhase.Started && IsGround()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * GameManager.Instance.Player.Stat.CharacterCurrentStat.JumpForce, ForceMode2D.Impulse);
            //if (jumpClip) SoundManager.PlayClip(jumpClip);
            GameManager.Instance.Player.PlayerAnim.JumpAnimStart();
        }
    }

    private bool IsGround()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f , GroundMask)) return true;
        return false;
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.left / 2, Vector3.right);
        Debug.DrawRay(transform.position + Vector3.left / 2, Vector3.right, Color.blue);
        Debug.Log(hit.collider);
        if (hit.collider == null) return;
        IInteractable interactable = hit.collider.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    public void OnLadder(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && Physics2D.Raycast(transform.position, Vector3.down, 1f, LadderMask))
        {
            GameManager.Instance.Player.PlayerAnim.PlayerAnimator.speed = 1;
            rb.gravityScale = 0;
            isLadder = true;
            currentMove = context.ReadValue<Vector2>();

        }
        else if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Canceled && Physics2D.Raycast(transform.position, Vector3.down, 0.5f, LadderMask))
        {
            GameManager.Instance.Player.PlayerAnim.PlayerAnimator.speed = 0;
            rb.gravityScale = 0;
            currentMove = Vector2.zero;
        } 
        else 
        {
            GameManager.Instance.Player.PlayerAnim.PlayerAnimator.speed = 1;
            rb.gravityScale = playerGravity;
            GameManager.Instance.Player.PlayerAnim.LadderAnimFinish();
            isLadder = false;
        }
    }

    private void Ladder()
    {
        
        targetVector.x = Vector2.zero.x;
        targetVector.y = currentMove.y * GameManager.Instance.Player.Stat.CharacterCurrentStat.Speed;
        rb.velocity = targetVector;
        GameManager.Instance.Player.PlayerAnim.LadderAnimStart();
        if (isLadder && !Physics2D.Raycast(transform.position + Vector3.down*0.5f, Vector3.down, 0.2f, LadderMask)) 
        {
            GameManager.Instance.Player.PlayerAnim.PlayerAnimator.speed = 1;
            rb.gravityScale = playerGravity;
            GameManager.Instance.Player.PlayerAnim.LadderAnimFinish();
            isLadder = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started && !IsAttack) 
        {
            //if (attackClip) SoundManager.PlayClip(attackClip);
            GameManager.Instance.Player.PlayerAnim.AttackAnimStart();
            IsAttack = true;
            
        }
    }

    public void OnDash(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started)
        {
            isDash = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(0, 0/*rb.velocity.y*/);
            if (!playerRenderer.flipX)  rb.AddForce(Vector2.right * GameManager.Instance.Player.Stat.CharacterCurrentStat.JumpForce*2f, ForceMode2D.Impulse);
            else rb.AddForce(Vector2.left * GameManager.Instance.Player.Stat.CharacterCurrentStat.JumpForce*2f, ForceMode2D.Impulse);
           // if (dashClip) SoundManager.PlayClip(dashClip);
            GameManager.Instance.Player.PlayerAnim.DashAnimStart();
        }
    }

    public void DashReset() 
    {
        isDash = false;
        rb.gravityScale = playerGravity;
    }

    private void WeaponFlip(bool leftVector) 
    {
        if (!leftVector)
        {
            WeaponPosition.transform.localScale = Vector3.one * weaponScale;
        }
        else 
        {
            WeaponPosition.transform.localScale = - Vector3.one * weaponScale;
        }
    }

}
