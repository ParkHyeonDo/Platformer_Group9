using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private bool isIdle;
    private bool isAttack;
    private bool isGround;
    private bool isHit;
    private Rigidbody2D rb;
    private Vector2 currentMove;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = currentMove * moveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        currentMove = context.ReadValue<Vector2>();
        isGround = true;
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Started && isGround) 
        {
            
            rb.AddForce(Vector2.up * 10f , ForceMode2D.Impulse);
            Debug.Log(rb.velocity);
            isGround = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
    
    }

    public void OnLadder(InputAction.CallbackContext context) 
    {
    
    }

    public void OnAttack(InputAction.CallbackContext context) 
    {
    
    }
}
