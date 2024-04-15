using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float screenWidth;
    public static float Speed = 8f;

    private float _addSpeed;
    private float _prevSpeed;

    IEnumerator GameEnd()
    {
        Speed = 0;
        yield return new WaitForSeconds(3f);
        Speed = _prevSpeed;
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene("SampleScene");
    }

    private void Start()
    {
        screenWidth = Screen.width;
        _addSpeed = 0f;
        _prevSpeed = 0f;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<Transform>().tag == "obs")
        {
            Destroy(other.gameObject);
        }

        if (GetComponent<Renderer>().material.color != other.GetComponent<Renderer>().material.color)
        {
            if (Speed > 8)
            {
                Speed /= 1.5f;
            }

            _prevSpeed = Speed;
            StartCoroutine(GameEnd());
        }
    }
}