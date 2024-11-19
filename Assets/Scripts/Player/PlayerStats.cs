using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour // for test
{
    public int maxHealth = 1000;
    public int maxMana = 500;
    public int currentHealth;
    public int currentMana;

    private void Start()
    {
        // �ʱ� �� ����
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // ü�� ȸ��
    public void RecoverHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"���� ü��: {currentHealth}/{maxHealth}");
    }

    // ���� ȸ��
    public void RecoverMana(int amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
        Debug.Log($"���� ����: {currentMana}/{maxMana}");
    }
}