using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var tempMousePosition = Input.mousePosition;
        
        tempMousePosition = Camera.main.ScreenToWorldPoint(tempMousePosition);
        tempMousePosition.z = 0;

        transform.position = Vector2.MoveTowards(transform.position, tempMousePosition, 2000 * Time.deltaTime);
    }
}
