using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class LadderClimb : MonoBehaviour
{
    private BoxCollider2D upGroundCollider;
    private BoxCollider2D downGroundCollider;
    private Transform ladderTop;
    public float disableDistance = 0.5f;


    void Update()
    {
        if (upGroundCollider == null || ladderTop == null) return;
        // 플레이어가 사다리 끝 근처에 있는지 확인
        float distanceToLadderTop = Vector2.Distance(transform.position, ladderTop.position);


        if (distanceToLadderTop <= disableDistance )
        {
            // 사다리 끝 근처에서 땅의 충돌체 비활성화
            upGroundCollider.enabled = false;
        }
        else
        {
            // 땅의 충돌체 활성화
                upGroundCollider.enabled = true;
                upGroundCollider = null;
                ladderTop = null;
        }
    }

    /*public void CheckGround() 
    {
        if (upGroundCollider != null) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position , Vector3.up, 1f, GameManager.Instance.Player.GroundMask);
        upGroundCollider = hit.collider as BoxCollider2D;
        
    }

    public void CheckLadderTop() 
    {
        if(ladderTop != null) return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.up, 2f, GameManager.Instance.Player.LadderTopMask);
        if (!hit) return;
        ladderTop = hit.collider.transform;
        
    }*/
}

