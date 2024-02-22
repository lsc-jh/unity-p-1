using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 20f;
    public float JumpForce = 300f;

    private bool canJump = true;

    private float level = 1;
    private float bestLevel = 1;

    public Text LevelText;
    public Text BestLevelText;

    // Start is called before the first frame update
    void Start()
    {
        BestLevelText.text = $"Best level: {bestLevel}";
        LevelText.text = $"Level: {level}";
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(0, 0, Speed * Time.deltaTime);

      if(Input.GetKey("a")){
        transform.Translate(-5 * Time.deltaTime, 0, 0);
      }

      if(Input.GetKey("d")){
        transform.Translate(5 * Time.deltaTime, 0, 0);
      }

      transform.Translate(Input.acceleration.x, 0, 0);

      if(Input.GetMouseButtonDown(0) && canJump){
        canJump = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
      }

      if(transform.position.y < -10){
        ResetGame();
      }
    }

    private void ResetGame() {
        transform.position = new Vector3(0, 1, 1);
        Speed = 20f;
        level = 1;
        LevelText.text = $"Level: {level}";
    }

    private void OnCollisionEnter(Collision collision){
      canJump = true;
      if(collision.gameObject.tag == "Obstacle"){
        ResetGame();
      }

      if(collision.gameObject.tag == "Finish") {
        transform.position = new Vector3(0, 1, 1);
        Speed += 5;
        level += 1;
        if (level > bestLevel) {
          bestLevel = level;
        }
        BestLevelText.text = $"Best level: {bestLevel}";
        LevelText.text = $"Level: {level}";
      }
    }
}
