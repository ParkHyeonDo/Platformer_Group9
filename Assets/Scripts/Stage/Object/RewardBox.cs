using System;
using UnityEngine;

public class RewardBox : MonoBehaviour, IInteractable
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
        Debug.Log("box");
        // TODO : ���� ���� �� ������ ������ ����
    }
}