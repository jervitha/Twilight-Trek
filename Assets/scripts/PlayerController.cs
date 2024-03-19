using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFacingLeft;
    private bool canDoubleJump;
    private Animator anim;
    private bool isGrounded;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpRadius;
    [SerializeField] private Transform groundCheckPos;
    
   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

   private void Update()
    {
        if (Time.timeScale > 0f)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, jumpRadius, whatIsGround);
            float xInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
            if (xInput > 0 && isFacingLeft == true)
            {
                Flip();
            }
            if (xInput < 0 && isFacingLeft == false)
            {
                Flip();
            }
            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                canDoubleJump = true;

            }
            else if (canDoubleJump == true)
            {
                Jump();
                canDoubleJump = false;
            }
            if (xInput != 0)
            {
                anim.SetBool(NewClass.IS_WALKING, true);

            }
            else
            {
                anim.SetBool(NewClass.IS_WALKING, false);
            }
            anim.SetBool(NewClass.IS_JUMPING, !isGrounded);
        }
    }
   private void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void Jump()
    {
       
    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
