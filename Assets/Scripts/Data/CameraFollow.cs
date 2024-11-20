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

    public Collider2D MapBoundary;
    private Bounds cameraBounds;

    private float cameraHalfHeight;
    private float cameraHalfWidth;

    private void Start()
    {
        if (PlayerTrans != null)
        {
            Offset = transform.position - PlayerTrans.position;
        }

        Camera mainCamera = Camera.main;
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

        if (MapBoundary != null)
        {
            cameraBounds = MapBoundary.bounds;
        }
    }

    private void LateUpdate()
    {
        if (PlayerTrans != null)
        {
            Vector3 targetPosition = PlayerTrans.position + Offset;

            targetPosition.x = Mathf.Clamp(targetPosition.x, cameraBounds.min.x + cameraHalfWidth, cameraBounds.max.x - cameraHalfWidth);
            targetPosition.y = Mathf.Clamp(targetPosition.y, cameraBounds.min.y + cameraHalfHeight, cameraBounds.max.y - cameraHalfHeight);

            transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        }
    }
}