using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerLogic : MonoBehaviour
{
	private int _coinCount = 0;
    public GameObject GemCountText;
    public GameObject FinishText;

    // Start is called before the first frame update
    void Start()
    {
        GemCountText.GetComponent<Text>().text = "Gem: " + _coinCount;
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

        if (other.gameObject.name == "Finish")
        {
            FinishText.SetActive(true);
        }
    }
}
