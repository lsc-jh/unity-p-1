using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform player;
    public Transform column;
    public GameObject platformPrefab;
    public GameObject badPlatformPrefab;

    private int badChance = 25;
    private GameObject platform;
    private float offset = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        for (var i = -3; i < 5; i++)
        {
            var platformCount = 0;
            SpawnPlatform(i, -offset, offset, -90, 0, ref platformCount);
            SpawnPlatform(i, offset, offset, -90, 90, ref platformCount);
            SpawnPlatform(i, -offset, -offset, -90, -90, ref platformCount);
            if (platformCount < 3)
            {
                SpawnPlatform(i, offset, -offset, -90, 180, ref platformCount);
            }
        }
    }

    // Update is called once per frame
    void Update()
    { }

    private void RandomPlatform()
    {
        if (Random.Range(0, 100) < badChance)
        {
            platform = badPlatformPrefab;
        }
        else
        {
            platform = platformPrefab;
        }

        //platform = Random.Range(0, 100) < badChance ? badPlatformPrefab : platformPrefab;
    }

    private void SpawnPlatform(int i, float offsetX, float offsetY, int rotX, int rotY, ref int count)
    {
        if (Random.Range(0, 2) == 1)
        {
            RandomPlatform();
            Instantiate(
                platform,
                column.transform.position + new Vector3(offsetX, i * 2f, offsetY),
                Quaternion.Euler(rotX, rotY, 0),
                column.transform
            );
            count++;
        }
    }
}
