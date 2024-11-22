using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour , IDamagable
{
    [SerializeField] private float HitDisableTime;

    private float checkDisableTime = float.MaxValue;
    private bool isHitted = false;
    private string playerTag = "Player";
    CharacterStatHandler characterStatHandler;

    public event Action HitDisableEnd;
    public event Action Ondamage;
    public GameObject gameOverUI;

    private float maxHealth;

    private void Awake()
    {
        characterStatHandler = GetComponent<CharacterStatHandler>();
    }
    private void Start()
    {
        maxHealth = characterStatHandler.CharacterCurrentStat.Health;
    }

    private void Update()
    {
        if (isHitted && checkDisableTime < HitDisableTime) // �ǰݽ� �����ڵ�
        {
            checkDisableTime += Time.deltaTime;
            if (checkDisableTime > HitDisableTime) 
            {
                HitDisableEnd?.Invoke();
                isHitted = false;
            }
        }
    }
    public bool TakeDamage(int Amount) 
    {
        if (checkDisableTime < HitDisableTime) return false;
        
        checkDisableTime = 0;
        characterStatHandler.CharacterCurrentStat.Health -= Amount;
        //characterStatHandler.CharacterCurrentStat.Health = (int)Mathf.Clamp(characterStatHandler.CharacterCurrentStat.Health, 0, maxHealth);
        Debug.Log($"�ǰ� �� ��� ü�� : {characterStatHandler.CharacterCurrentStat.Health} / ���� ���ݷ� : {Amount}");

        if (characterStatHandler.CharacterCurrentStat.Health <= 0)
        {
            Die();
            return true;
        }
        else 
        {
            Ondamage?.Invoke();
            isHitted = true;
        }
        return true;
    }

    public void Die() 
    {
        if (this.gameObject.CompareTag(playerTag)) 
        {
            Debug.Log("�÷��̾� ���");
            gameOverUI.SetActive(true);
            return;
        }
        
        // ���� �ִϸ��̼� ����
        Destroy(gameObject);
    }
}
