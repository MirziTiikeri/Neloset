using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 5f;
    public float JumpForce = 7.5f;

    private float HorizontalMovement = 0f;

    public Rigidbody2D MyRigidbody2D;

    public CircleCollider2D Feet;

    public Animator Animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            MyRigidbody2D.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            Animator.SetTrigger("JumpTrigger");
        }
        if (Feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            Animator.SetBool("IsTouchingGround", true);
        } else {
            Animator.SetBool("IsTouchingGround", false);
        }
    }

    void FixedUpdate() 
    {
        MyRigidbody2D.velocity = new Vector2(HorizontalMovement * Speed, MyRigidbody2D.velocity.y);
    }

}
