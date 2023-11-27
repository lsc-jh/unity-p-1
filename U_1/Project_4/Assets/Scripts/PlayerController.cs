using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 jumpForce = new Vector3(0, 5, 0);
    private bool hasCollide = false;

    public Text LevelText;
    public Text BestLevelText;

    private static int level = 1;
    private static int bestLevel = 0;

    // Update is called once per frame
    void Update()
    {
        bestLevel = bestLevel < level ? level : bestLevel;
        
        LevelText.text = $"Level: {level}";
        BestLevelText.text = $"Best Level: {bestLevel}";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!hasCollide)
        {
            if (other.gameObject.tag == "badPlatform")
            {
                level = 1;
                SceneManager.LoadScene("SampleScene");
            }

            if (other.gameObject.name == "FullPlatform")
            {
                level++;
                SceneManager.LoadScene("SampleScene");
            }
            
            hasCollide = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        hasCollide = false;
    }
}
