using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private MonsterAnimationController animator;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponentInParent<MonsterAnimationController>();

        if (animator == null)
        {
            Debug.LogError("부모 객체에 MonsterAnimationController가 없습니다!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null && Time.time >= lastAttackTime + 1)
            {
                animator.TriggerAttack();
                animator.SetAttack(true);
                Debug.Log("공격 애니메이션 실행");
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
                Debug.Log("걷기 애니메이션으로 전환");
            }
        }
    }
}
