using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTrans;
    public Vector3 Offset;

    private void Start()
    {
        if (PlayerTrans != null)
        {
            Offset = transform.position - PlayerTrans.position;
        }
    }

    private void LateUpdate()
    {
        if (PlayerTrans != null)
        {
            transform.position = PlayerTrans.position + Offset;
        }
    }
}


