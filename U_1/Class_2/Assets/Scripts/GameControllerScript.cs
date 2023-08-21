using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public PlayerLogic player;
    public Camera gameCamera;
    [SerializeField]
    public GameObject Joystick;
    
    
    void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            Joystick.SetActive(false);
        }
        else
        {
            Joystick.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameCamera.transform.position = new Vector3(
            Mathf.Lerp(gameCamera.transform.position.x, player.transform.position.x, 0.001f),
            player.transform.position.y,
            Mathf.Lerp(gameCamera.transform.position.z, player.transform.position.z - 15, 0.1f)
        );
    }
}
