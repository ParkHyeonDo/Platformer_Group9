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

    public event Action HitDisableEnd;
    public event Action Ondamage;

    private float maxHealth;

    private void Start()
    {
        maxHealth = GameManager.Instance.Player.Stat.CharacterCurrentStat.Health;
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
        GameManager.Instance.Player.Stat.CharacterCurrentStat.Health -= Amount;
        GameManager.Instance.Player.Stat.CharacterCurrentStat.Health = (int)Mathf.Clamp(GameManager.Instance.Player.Stat.CharacterCurrentStat.Health, 0, maxHealth);


        if (GameManager.Instance.Player.Stat.CharacterCurrentStat.Health <= 0)
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
            Debug.Log("플레이어 사망");
            return;
        }
        // 몬스터 애니메이션 연결
        Destroy(gameObject);
    }
}
