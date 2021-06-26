using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2d;
    private float speed = 5f;
    private float directionX;
    private bool facingRight = true;
    private Vector3 localScale;


    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Controll();
        Checker();
    }

    private void Controll()
    {
        directionX = Input.GetAxisRaw("Horizontal") * speed;
        
        if (Input.GetButtonDown("Jump") && rb2d.velocity.y == 0)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(new Vector2(0, 1500f));
        }
    }

    private void Checker()
    {
        if (Mathf.Abs(directionX) > 0 && rb2d.velocity.y == 0) //Mathf.Abs = membuat angka jadi tetap positif atau absolute value
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (rb2d.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (rb2d.velocity.y > 1f)
        {
            animator.SetBool("isJumping", true);
        }

        if (rb2d.velocity.y > 1f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }

    }

    private void Flip()
    {
        if (directionX > 0)
        {
            facingRight = true;
        }
        else if (directionX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && localScale.x < 0) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(directionX, rb2d.velocity.y);

    }
    private void LateUpdate()
    {
        Flip();
    }
}
