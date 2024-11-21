using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    [Header("애니메이션")]
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
        animator = GetComponent<Animator>();

        // 메모리 최적화
        isMoveAnim = Animator.StringToHash(isMoveTr);
        isJumpAnim = Animator.StringToHash(isJumpTr);
        isAttackAnim = Animator.StringToHash(isAttackTr);
        isLadderAnim = Animator.StringToHash(isLadderTr);
        isDashAnim = Animator.StringToHash(isDashTr);
    }

    public void MoveAnimStart() 
    {
        animator.SetBool(isMoveAnim, true);
    }

    public void JumpAnimStart() 
    {
    
    }

    public void AttackAnimStart() { }

    public void LadderAnimStart() { }

    public void DashAnimStart() { }

    


}

