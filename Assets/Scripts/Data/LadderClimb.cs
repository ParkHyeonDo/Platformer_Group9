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

}

