using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    private bool _isSpawning = true;
    public GameObject Obstacle;

    void Start()
    {
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            if (_isSpawning)
            {
                var obstacle = ObjectPools.Instance.Get();
                var obsContainer = Obstacle.GetComponentInChildren<Transform>();
                var child = obsContainer.GetChild(Random.Range(0, 4));
                
                obstacle.transform.position = child.position;
                obstacle.transform.rotation = transform.rotation;
                obstacle.gameObject.SetActive(true);
            }
            else
            {
                Instantiate(Obstacle);
            }

            _isSpawning = !_isSpawning;
            yield return new WaitForSeconds(10f / PlayerController.Speed);
        }
    }
}