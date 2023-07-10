using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private bool _canJump = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canJump)
        {
            _canJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }
    }

    private void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-MoveForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(MoveForce * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        _canJump = true;
    }
}
