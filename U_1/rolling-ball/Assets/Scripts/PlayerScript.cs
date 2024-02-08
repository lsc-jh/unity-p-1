using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed = 20f;
    public float JumpForce = 300f;

    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
      
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

      if(Input.GetMouseButtonDown(0) && canJump){
        canJump = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpForce, 0));
      }

      if(transform.position.y < 0){
        transform.position = new Vector3(0, 1, 1);
      }
    }

    private void OnCollisionEnter(Collision collision){
      canJump = true;
      if(collision.gameObject.tag == "Obstacle"){
        transform.position = new Vector3(0, 1, 1);
      }
    }
}
