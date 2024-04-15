using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 3f, 0);
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position - Vector3.forward,
            Mathf.Round(PlayerController.Speed) * Time.deltaTime
        );
        
        if (transform.position.z < -9f)
        {
            ObjectPools.Instance.ReturnToPool(this);
        }
    }
}
