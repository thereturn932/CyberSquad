using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUiManager : MonoBehaviour
{
    //Canvases
    public Canvas inGameUi;
    public Canvas pauseMenu;
    public Canvas victoryCanvas;

    //Time Variables to control pause
    private float defaultTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        //Save current time scale
        defaultTimeScale = Time.timeScale;

        inGameUi.enabled = true;
        pauseMenu.enabled = false;
        victoryCanvas.enabled = false;
    }


    //Pause Button Press Method
    public void OnPauseButtonPressed()
    {
        Time.timeScale = 0;
        inGameUi.enabled = false;
        pauseMenu.enabled = true;
        victoryCanvas.enabled = false;
    }

    //Resume Button Press Method
    public void OnResumeButtonPressed()
    {
        Time.timeScale = defaultTimeScale;
        inGameUi.enabled = true;
        pauseMenu.enabled = false;
        victoryCanvas.enabled = false;
    }

    //Main Manu Button Press Method
    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //Exit Button Press Method
    public void OnExitButtonPressed()
    {
        print("Exit");
        Application.Quit();
    }

    //Victory Method
    public void VictoryScreen()
    {
        Time.timeScale = defaultTimeScale;
        inGameUi.enabled = false;
        pauseMenu.enabled = false;
        victoryCanvas.enabled = true;
        Time.timeScale = 0;
    }
}
