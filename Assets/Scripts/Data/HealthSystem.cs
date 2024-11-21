using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour , IDamagable
{
    [SerializeField] private float HitDisableTime;

    private float checkDisableTime;
    private bool isHitted = false;

    public event Action HitDisableEnd;
    public event Action Ondamage;

    private float maxHealth;

    private void Awake()
    {

    }
    private void Start()
    {
        maxHealth = GameManager.Instance.Player.Stat.PlayerCurrentStat.Health;
    }

    private void Update()
    {
        if (isHitted && checkDisableTime < HitDisableTime) // 피격시 실행코드
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
        GameManager.Instance.Player.Stat.PlayerCurrentStat.Health -= Amount;
        GameManager.Instance.Player.Stat.PlayerCurrentStat.Health = (int)Mathf.Clamp(GameManager.Instance.Player.Stat.PlayerCurrentStat.Health, 0, maxHealth);


        if (GameManager.Instance.Player.Stat.PlayerCurrentStat.Health <= 0)
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
        if (this.gameObject.CompareTag("Player")) 
        {
            Debug.Log("플레이어 사망");
        }
    }
}
