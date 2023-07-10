using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject Collectable;
    public GameObject BadCollectable;
    
    float randomXCollectable = 0f;
    float randomYCollectable = 0f;

    float randomXBadCollectable = 0f;
    float randomYBadCollectable = 0f;

    float collectableSpawnTime = 1f;
    float badCollectableSpawnTime = 1f;

    float maxX = 17.5f;
    float maxY = 9f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCollectables());
        StartCoroutine(SpawnBadCollectables());
    }

    IEnumerator SpawnCollectables(){
        while(true){
            SpawnCollectable();
            yield return new WaitForSeconds(collectableSpawnTime);
        }
    }

    IEnumerator SpawnBadCollectables(){
        while(true){
            SpawnBadCollectable();
            yield return new WaitForSeconds(badCollectableSpawnTime);
        }
    }

    void SpawnCollectable(){
        randomXCollectable = Random.Range(-maxX, maxX);
        randomYCollectable = Random.Range(-maxY, maxY);

        Instantiate(Collectable, new Vector3(randomXCollectable, randomYCollectable, 0), Quaternion.identity);
    }

    void SpawnBadCollectable(){
        randomXBadCollectable = Random.Range(-maxX, maxX);
        randomYBadCollectable = Random.Range(-maxY, maxY);

        Instantiate(BadCollectable, new Vector3(randomXBadCollectable, randomYBadCollectable, 0), Quaternion.identity);
    }



}
