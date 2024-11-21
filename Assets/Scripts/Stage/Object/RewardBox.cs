using System;
using UnityEngine;

public class RewardBox : MonoBehaviour
{
    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            OpenBox();
        }
    }

    private void OpenBox()
    {
        // TODO : 상자 오픈 시 나오는 리워드 지급
    }
}