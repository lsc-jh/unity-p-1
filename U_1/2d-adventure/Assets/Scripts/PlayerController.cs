using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 20f;
    public float JumpForce = 400f;
    public float HorizontalForce;
    private bool jump = false;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalForce = Input.GetAxis("Horizontal") * MovementSpeed;

        if (HorizontalForce > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        
        if (HorizontalForce < 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        Moving(HorizontalForce, jump);
    }

    private void Moving(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);
        if(canJump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, JumpForce));
            jump = false;
        }
    }
}
