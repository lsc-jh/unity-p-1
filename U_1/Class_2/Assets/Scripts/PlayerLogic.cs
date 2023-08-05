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

    private Vector2 _swipeStartPosition;
    private Vector2 _swipeEndPosition;
    
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("The screen got touched");
                _swipeStartPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("The screen got released.");
                _swipeEndPosition = touch.position;
                if (_swipeStartPosition.y < _swipeEndPosition.y)
                {
                    _hasSiwtchedLayers = true;
                } 
                else if (_swipeStartPosition.y > _swipeEndPosition.y)
                {
                    _hasSiwtchedLayers = false;
                }
            }
        }
        
        
        
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

        if (transform.position.y < -10)
        {
            _hasSiwtchedLayers = false;
            transform.position = new Vector3(-15, 1.5f, 0);
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

        if (other.gameObject.tag == "tramp")
        {
            GetComponent<Rigidbody>().AddForce(0, 750, 0);
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
