using UnityEngine;
public class Trap : StageObject
{
    public int Damage = 10;

    public override void OnPlayerEnter(GameObject player)
    {
        //PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        //if (playerHealth != null)
        //{
        //    playerHealth.TakeDamage(Damage);
        //}
    }
}