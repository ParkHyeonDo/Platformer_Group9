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
            Debug.LogError("�θ� ��ü�� MonsterAnimationController�� �����ϴ�!");
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
                Debug.Log("���� �ִϸ��̼� ����");
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
                Debug.Log("�ȱ����� ��ȯ");
            }
        }
    }
}
