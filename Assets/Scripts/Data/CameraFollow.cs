using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTrans;
    public Vector3 Offset;
    private Rigidbody2D cameraRb;

    private void Start()
    {
        if (PlayerTrans != null)
        {
            Offset = transform.position - PlayerTrans.position;
        }

        cameraRb = GetComponentInChildren<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (PlayerTrans != null && cameraRb != null)
        {
            Vector3 targetPosition = PlayerTrans.position + Offset;
            cameraRb.MovePosition(new Vector2(targetPosition.x, targetPosition.y));
        }
    }
}


