using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotateSpeed = 200f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, -RotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime, 0));
        // you don't need this
        Debug.Log($"{Input.GetAxis("Mouse X")} -> {-RotateSpeed * Input.GetAxis("Mouse X") * Time.deltaTime}");
    }
}
