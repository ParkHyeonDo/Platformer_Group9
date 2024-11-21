using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ContactAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
        if (healthSystem != null) 
        {
            //bool DamageApply = healthSystem.TakeDamage(-)
        }
    }
}
