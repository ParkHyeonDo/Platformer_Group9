using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private MonsterAnimationController animator;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponentInParent<MonsterAnimationController>();

       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null && Time.time >= lastAttackTime + 1)
            {
                animator.TriggerAttack();
                animator.SetAttack(true);
              
                lastAttackTime = Time.time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null)
            {
                animator.SetWalking(true);
              
            }
        }
    }
}
