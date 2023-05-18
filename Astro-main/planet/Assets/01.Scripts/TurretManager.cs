using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pausegame;

    void Update()
    {   if (Input.GetKeyDown(KeyCode.Escape))
        {
        
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausegame.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;


    }

    public void ResumeGame()
    {
        pausegame.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }
}

   