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
        // 초기 값 설정
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // 체력 회복
    public void RecoverHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"현재 체력: {currentHealth}/{maxHealth}");
    }

    // 마나 회복
    public void RecoverMana(int amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
        Debug.Log($"현재 마나: {currentMana}/{maxMana}");
    }
}