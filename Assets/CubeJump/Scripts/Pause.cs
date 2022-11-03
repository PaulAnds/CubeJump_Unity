using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool GameIsPaused = false;
    public LevelManager LevelWarning;
    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        LevelWarning = FindObjectOfType<LevelManager>();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        if (!GameIsPaused)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            LevelWarning.timer = true;
            LevelWarning.time = 4;
            LevelWarning.ui.SetActive(true);
            GameIsPaused = false;
        }
    }
}
