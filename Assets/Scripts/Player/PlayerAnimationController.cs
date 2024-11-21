using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
    [Header("애니메이션")]
    [HideInInspector]
    public Animator PlayerAnimator;
    private HealthSystem healthSystem;
    private string isMoveTr = "isMove";
    private string isJumpTr = "isJump";
    private string isAttackTr = "isAttack";
    private string isLadderTr = "isLadder";
    private string isDashTr = "isDash";
    private int isMoveAnim;
    private int isJumpAnim;
    private int isAttackAnim;
    private int isLadderAnim;
    private int isDashAnim;

    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();

        // 메모리 최적화
        isMoveAnim = Animator.StringToHash(isMoveTr);
        isJumpAnim = Animator.StringToHash(isJumpTr);
        isAttackAnim = Animator.StringToHash(isAttackTr);
        isLadderAnim = Animator.StringToHash(isLadderTr);
        isDashAnim = Animator.StringToHash(isDashTr);
        
    }

    private void Start()
    {
        healthSystem.Ondamage += Hit;
    }

    public void MoveAnimStart() 
    {
        PlayerAnimator.SetBool(isMoveAnim, true);
    }

    public void MoveAnimFinish()
    {
        PlayerAnimator.SetBool(isMoveAnim, false);
    }

    public void JumpAnimStart() 
    {
        PlayerAnimator.SetBool(isJumpAnim, true);
    }

    public void JumpAnimFinish() 
    {
        PlayerAnimator.SetBool(isJumpAnim, false);
    }

    public void AttackAnimStart() 
    {
        PlayerAnimator.SetBool(isAttackAnim, true);
    }
    public void AttackAnimFinish() 
    {
        PlayerAnimator.SetBool(isAttackAnim, false);
        GameManager.Instance.Player.Controller.IsAttack = false;
    }

    public void LadderAnimStart() 
    {
        PlayerAnimator.SetBool(isLadderAnim, true);
    }
    public void LadderAnimFinish() 
    {
        PlayerAnimator.SetBool(isLadderAnim, false);
    }

    public void DashAnimStart() 
    {
        PlayerAnimator.SetBool(isDashAnim, true);
    }
    public void DashAnimFinish() 
    {
        PlayerAnimator.SetBool(isDashAnim, false);
        GameManager.Instance.Player.Controller.DashReset();
    }

    public void Hit() 
    {
        
    }
}

