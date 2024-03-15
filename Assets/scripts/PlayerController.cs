using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    bool isFacingLeft;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpRadius;
    [SerializeField] private Transform groundCheckPos;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position,jumpRadius,whatIsGround);
        float xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        if(xInput>0 && isFacingLeft==true)
        {
            Flip();
        }
        if(xInput<0 &&isFacingLeft==false)
        {
            Flip();
        }
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        { 
            rb.velocity = Vector2.up * jumpForce;
        }


    }
    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

    }
}
