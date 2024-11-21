using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private MonsterAnimationController parentAnimController;
    public float attackCooldown = 120f; // 공격 간 쿨다운 시간
    private float lastAttackTime;

    void Start()
    {
        parentAnimController = GetComponentInParent<MonsterAnimationController>();

        if (parentAnimController == null)
        {
            Debug.LogError("부모 객체에 MonsterAnimationController가 없습니다!");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentAnimController != null && Time.time >= lastAttackTime + attackCooldown)
            {
                parentAnimController.TriggerAttack();
                Debug.Log("공격 애니메이션 실행");
                lastAttackTime = Time.time;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (parentAnimController != null)
            {
                parentAnimController.SetWalking(true);
                Debug.Log("걷기 애니메이션으로 전환");
            }
        }
    }
}
