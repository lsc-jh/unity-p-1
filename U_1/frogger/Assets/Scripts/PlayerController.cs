using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // DONT FORGET THIS ONE

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 20f)
        {
            SceneManager.LoadScene("SampleScene");            
        }
    }
}
