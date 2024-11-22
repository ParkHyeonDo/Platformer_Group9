using UnityEngine;

public class JumpPad : StageObject
{
    public int JumpForce = 10;

    public override void OnPlayerEnter(GameObject player)
    {
        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

        if (playerRb != null)
        {
            playerRb.velocity = new  Vector2(playerRb.velocity.x, JumpForce);
        }
    }
}