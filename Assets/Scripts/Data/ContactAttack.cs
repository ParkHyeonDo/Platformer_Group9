using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ContactAttack : MonoBehaviour
{
    private CharacterStatHandler characterStat;
    private BoxCollider2D attackRange;
    private bool isAttack;

    private void Start()
    {
        characterStat = GetComponentInParent<CharacterStatHandler>();
        attackRange = GetComponent<BoxCollider2D>();
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null) 
        {
            bool DamageApply = healthSystem.TakeDamage(+characterStat.CharacterCurrentStat.Damage/*##강화스탯 추가*/);
            
            if (DamageApply && characterStat.CharacterCurrentStat.HaveKnockback) 
            {
                Knockback(collision);
            }
        }
    }

    private void Knockback(Collider2D collision) 
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = collision.GetComponent<SpriteRenderer>();
        if (spriteRenderer.flipX)
        {
            rb.AddForce(Vector2.right * characterStat.CharacterCurrentStat.KnockbackForce * 10f, ForceMode2D.Impulse);
        }
        else 
        {
            rb.AddForce(Vector2.left * characterStat.CharacterCurrentStat.KnockbackForce * 10f, ForceMode2D.Impulse);
        }
    }


}
