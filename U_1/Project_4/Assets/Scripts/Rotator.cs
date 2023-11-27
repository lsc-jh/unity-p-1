using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, -200f * Input.GetAxis("Mouse X") * Time.deltaTime, 0));
        // you don't need this
        Debug.Log($"{Input.GetAxis("Mouse X")} -> {-150f * Input.GetAxis("Mouse X") * Time.deltaTime}");
    }
}
