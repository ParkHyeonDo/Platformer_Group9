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
        InvokeRepeating("Strike", strikeDelay, strikeDelay); // 일정 시간마다 낙뢰를 떨어뜨림
    }

    private void Strike()
    {
        // 랜덤한 위치에 낙뢰 생성)
        Vector3 strikePosition = new Vector3(Random.Range(-5f, 5f), transform.position.y + 5f, 0);
        GameObject lightning = Instantiate(lightningPrefab, strikePosition, Quaternion.identity);
        lightning.transform.localScale = new Vector3(3f, 3f, 3f);
        // 낙뢰가 떨어지는 효과를 주기 위해 코루틴 사용
        StartCoroutine(DropLightning(lightning));
    }

    private IEnumerator DropLightning(GameObject lightning)
    {
        float fallSpeed = 10f; // 낙뢰의 속도
        Vector3 startPosition = lightning.transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y - 5f, startPosition.z); // 아래로 떨어짐

        while (lightning.transform.position.y > targetPosition.y)
        {
            lightning.transform.position = Vector3.MoveTowards(lightning.transform.position, targetPosition, fallSpeed * Time.deltaTime);
            yield return null; // 다음 프레임까지 대기
        }

        DealDamage();
        Destroy(lightning);
    }

    private void DealDamage()
    {
        Debug.Log("낙뢰가 떨어져 피해를 줌: " + damage);
    }
}
