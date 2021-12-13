using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    //Canvases
    [SerializeField]
    private Canvas mainMenu;
    [SerializeField]
    private Canvas Options;
    [SerializeField]
    private Canvas CreditCanvas;

    //Options Variables
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    /* 
     * Disable canvases except main menu at the beginning.
     */
    private void Start()
    {
        mainMenu.enabled = true;
        Options.enabled = false;
        CreditCanvas.enabled = false;
    }

    #region UI Managing
    //Play Button Press Method
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }

    //Options Button Press Method
    public void OnOptionsButtonPressed()
    {
        GetResolution();
        mainMenu.enabled = false;
        Options.enabled = true;
        CreditCanvas.enabled = false;
    }

    //Gets resolution the computer capable of and add them to resolution list
    private void GetResolution()
    {
        //Clear previously added resolutions
        resolutionDropdown.ClearOptions();
        //Create a list to hold resolutions available will be set into dropdown menu
        List<string> resolutionList = new List<string>();
        //Fill array with resolutions available
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        //Put every resolution in array to list in a provided format
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionList.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        //Reverse list
        resolutionList.Reverse();

        //Set list into dropdown menu
        resolutionDropdown.AddOptions(resolutionList);

        //Update dropdown menu value
        resolutionDropdown.RefreshShownValue();
    }

    //Exit Button Press Method
    public void OnExitButtonPressed()
    {
        print("Exit");
        Application.Quit();
    }

    //Main Manu Button Press Method
    public void OnMainMenuButtonPressed()
    {
        mainMenu.enabled = true;
        Options.enabled = false;
        CreditCanvas.enabled = false;
    }

    //Credit Button Press Method
    public void OnCreditButtonPressed()
    {
        mainMenu.enabled = false;
        Options.enabled = false;
        CreditCanvas.enabled = true;
    }
    #endregion

    #region OptionMethods
    //Change Volume Method
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    //Full Screen Check Method
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //Set Resolution Method
    public void SetResolution(int resolutionInd)
    {
        Resolution resolution = resolutions[resolutionInd];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Set Texture Quality Method
    public void SetTextureQuality(int textureQualityIndex)
    {
        QualitySettings.masterTextureLimit = textureQualityIndex;
    }
    #endregion
}
