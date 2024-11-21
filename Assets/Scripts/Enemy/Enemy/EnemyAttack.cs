using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private MonsterAnimationController parentAnimController;
    public float attackCooldown = 120f; // ���� �� ��ٿ� �ð�
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
            if (parentAnimController != null && Time.time >= lastAttackTime + attackCooldown)
            {
                parentAnimController.TriggerAttack();
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
                Debug.Log("�ȱ� �ִϸ��̼����� ��ȯ");
            }
        }
    }
}
