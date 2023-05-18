using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject optionMenuCanvas;
    public void OpenOptionMenu()
    {
        Time.timeScale = 0f;
        optionMenuCanvas.SetActive(true);
        pauseMenuUI.SetActive(false);

    }
}