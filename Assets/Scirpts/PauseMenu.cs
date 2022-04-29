using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    public static bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickOnPauseButton()
    {
        if (isGamePaused)
            return;

        if (!isGamePaused)
        {
            Pause();
        }
    }

    void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
