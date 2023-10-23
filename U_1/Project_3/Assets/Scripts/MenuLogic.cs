using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuLogic : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseUi;
    public FirstPersonController Controller;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            Controller.enabled = !IsGamePaused;
        } 
    }

    public void Resume()
    {
        PauseUi.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void Pause()
    {
        PauseUi.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void LoadMenu()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
