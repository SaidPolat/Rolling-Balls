using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown dropdown;
    public Animator transition;
    public Dropdown resolutionDropdown;
    public AudioManager audioManager;


    public static float musicVolume;
    public static float sfxVolume;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float volume)
    {
        for (int i = 0; i < 3; i++)
        {
            audioManager.sounds[i].volume = volume;
        }
        musicVolume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        for (int i = 4; i < 7; i++)
        {
            audioManager.sounds[i].volume = volume - 1.3f;
        }
        for (int i = 7; i < 12; i++)
        {
            audioManager.sounds[i].volume = volume;
        }
        sfxVolume = volume;
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        transition.SetTrigger("Loading");
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
