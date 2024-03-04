using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float screenWidth;

    private void Start()
    {
        screenWidth = Screen.width;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -1.5f)
        {
            transform.position += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5f)
        {
            transform.position += Vector3.right;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            
            if (touch.position.x < screenWidth / 2f && touch.phase == TouchPhase.Ended)
            {
                transform.position += Vector3.left;
            }
            
            
            if (touch.position.x > screenWidth / 2f && touch.phase == TouchPhase.Ended)
            {
                transform.position += Vector3.right;
            }
        }
    }
}