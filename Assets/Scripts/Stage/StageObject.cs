using UnityEngine;

public abstract class StageObject : MonoBehaviour
{
    public abstract void OnPlayerEnter(GameObject player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnPlayerEnter(collision.gameObject);
        }
    }
}
