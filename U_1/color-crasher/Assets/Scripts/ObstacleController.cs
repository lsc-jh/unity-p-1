using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position - Vector3.forward,
            Mathf.Round(PlayerController.Speed) * Time.deltaTime
        );
        
        Debug.Log("ObstacleController Speed: " + PlayerController.Speed);

        if (transform.position.z < -9f)
        {
            if(transform.childCount >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
