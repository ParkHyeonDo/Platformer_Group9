using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Animator animator;
    public GameObject lightningPrefab; 
    public float strikeDelay = 2f; 
    public float damage = 200f; 

    private void Start()
    {
        InvokeRepeating("Strike", strikeDelay, strikeDelay); // ���� �ð����� ���ڸ� ����߸�
    }

    private void Strike()
    {
        // ������ ��ġ�� ���� ����)
        Vector3 strikePosition = new Vector3(Random.Range(-5f, 5f), transform.position.y + 5f, 0);
        GameObject lightning = Instantiate(lightningPrefab, strikePosition, Quaternion.identity);
        lightning.transform.localScale = new Vector3(3f, 3f, 3f);
        // ���ڰ� �������� ȿ���� �ֱ� ���� �ڷ�ƾ ���
        StartCoroutine(DropLightning(lightning));
    }

    private IEnumerator DropLightning(GameObject lightning)
    {
        float fallSpeed = 10f; // ������ �ӵ�
        Vector3 startPosition = lightning.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y - 5f, startPosition.z); // �Ʒ��� ������

        while (lightning.transform.position.y > targetPosition.y)
        {
            lightning.transform.position = Vector3.MoveTowards(lightning.transform.position, targetPosition, fallSpeed * Time.deltaTime);
            yield return null; // ���� �����ӱ��� ���
        }

        DealDamage();
        Destroy(lightning);
    }

    private void DealDamage()
    {
        Debug.Log("���ڰ� ������ ���ظ� ��: " + damage);
    }
}
