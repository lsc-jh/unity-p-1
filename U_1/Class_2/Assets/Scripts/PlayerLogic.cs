using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float JumpForce;
    public float MoveForce;
    private bool _canJump = false;
    private bool _hasSiwtchedLayers = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canJump)
        {
            _canJump = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_hasSiwtchedLayers)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    0
                );
            }
            else
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    10
                );
            }

            _hasSiwtchedLayers = !_hasSiwtchedLayers;
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
        
        var initX = -15;
        for (var i = 0; i < 5; i++)
        {
            var currentPlayerX = (80 * (i + 1)) - 15;
            CheckFinish(other.gameObject, $"Finish{i + 1}", currentPlayerX, 1.5f);
        }


        if (other.gameObject.tag == "obstacle")
        {
            MovePlayer(-13, 1.5f);
        }
    }

    private void MovePlayer(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
        _hasSiwtchedLayers = false;
    }

    private void CheckFinish(GameObject finishObject, string finishName, float x, float y)
    {
        if (finishObject.name == finishName)
        {
            MovePlayer(x, y);
        }
    }
}