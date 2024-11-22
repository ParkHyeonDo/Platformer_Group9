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
        Camera mainCamera = Camera.main;
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;

        Offset = new Vector3(0, 0, -10);

        if (PlayerTrans != null)
        {
            transform.position = PlayerTrans.position + Offset;
        }

        if (MapBoundary != null)
        {
            cameraBounds = MapBoundary.bounds;
        }
    }

    private void LateUpdate()
    {
        if (PlayerTrans == null)
        {
            return;
        }

        Offset = new Vector3(0, 0, -10);

        Vector3 targetPosition = PlayerTrans.position + Offset;

        if (MapBoundary != null)
        {
            targetPosition.x = Mathf.Clamp(targetPosition.x, cameraBounds.min.x + cameraHalfWidth, cameraBounds.max.x - cameraHalfWidth);
            targetPosition.y = Mathf.Clamp(targetPosition.y, cameraBounds.min.y + cameraHalfHeight, cameraBounds.max.y - cameraHalfHeight);
        }

        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
    }

    public void SetMapBoundary(Collider2D mapBoundary)
    {
        if (mapBoundary != null)
        {
            MapBoundary = mapBoundary;
            cameraBounds = MapBoundary.bounds;
        }
    }

    public void SetPlayer(Transform playerTransform)
    {
        PlayerTrans = playerTransform;
        Offset = transform.position - PlayerTrans.position;
    }
}