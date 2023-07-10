using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour
{
    public ScoreLogic ScoreLogic;
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

        transform.position = Vector3.MoveTowards(transform.position, tempMousePosition, 2000 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "collectable"){
            ScoreLogic.Score += 1;
            Destroy(other.gameObject);
            Debug.Log("Coll");
        }
        else if(other.gameObject.tag == "badCollectable"){
            SceneManager.LoadScene("SampleScene");
            Debug.Log("BadCol");
        }
    }
}
