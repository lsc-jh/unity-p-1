using UnityEngine;

public class Move : MonoBehaviour
{
    public float Delta = 2f;
    public float Speed = 2f;
    public float RotationSpeed = 1f;
    private Vector3 _startPos;
    
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotationSpeed, 0);
        var v = _startPos;
        v.x += Delta * Mathf.Sin(Time.time * Speed);
        transform.position = v;
    }
}
