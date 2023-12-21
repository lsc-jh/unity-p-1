using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject platform;
    private Vector3 spawn_1 = new Vector3(51.5f, 23, 0);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawning());       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawning()
    {
        while(true) 
        {
            yield return new WaitForSeconds(Random.Range(3f, 6f));

            if(Random.Range(0, 2) == 1)
            {
                Instantiate(platform, spawn_1, Quaternion.identity);
            }
        }
    }
}
