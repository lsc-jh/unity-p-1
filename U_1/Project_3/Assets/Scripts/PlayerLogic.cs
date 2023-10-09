using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
	private int _coinCount = 0;
    public GameObject GemCountText;

    // Start is called before the first frame update
    void Start()
    {
        GemCountText.GetComponent<Text>().text = "Gem: " + _coinCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
            _coinCount++;
            GemCountText.GetComponent<Text>().text = "Gem: " + _coinCount.ToString();
        }
    }
}
