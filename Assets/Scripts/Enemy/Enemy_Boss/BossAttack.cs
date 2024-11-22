using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private MonsterAnimationController parentAnimController;
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
            if (parentAnimController != null && Time.time >= lastAttackTime + 3)
            {
                parentAnimController.TriggerAttack();
                parentAnimController.SetAttack(true);
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
                Debug.Log("걷기으로 전환");
            }
        }
    }
}
